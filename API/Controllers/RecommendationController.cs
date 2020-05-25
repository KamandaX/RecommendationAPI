using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecommendationController : ApiControllerBase
    {
        private readonly IScoreService _scoreService;
        private const float ScoreThreshold = 2.5f;

        public RecommendationController(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter,
            IScoreService scoreService) :
            base(context, serializer, errorFormatter)
        {
            _scoreService = scoreService;
        }

        [HttpPost]
        public async Task<ActionResult<RecommendationDTO>> GetRecommendation(AnsweredQuestionDTO[] questions)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid Headers!");
            }

            var aspectScores = _scoreService.GetAspectScores(questions);

            float priceScore;
            try
            {
                priceScore = aspectScores[(int) AspectType.PriceScore] * 10;
            }
            catch (Exception)
            {
                return ApiBadRequest("Price score not provided!");
            }

            float minPrice = priceScore - ScoreThreshold;
            float maxPrice = priceScore + ScoreThreshold;

            var eligiblePhones = await Context.Phones
                .Include(i => i.Score)
                .Include(i => i.Cameras)
                .Where(i => i.Score.PriceScore >= minPrice && i.Score.PriceScore <= maxPrice)
                .ToListAsync()
                .ConfigureAwait(false);

            return eligiblePhones.Count switch
            {
                0 => ApiNotFound("No phone within eligible price range"),
                1 => Ok(new RecommendationDTO(eligiblePhones[0])),
                _ => Ok(FormRecommendation(eligiblePhones, aspectScores)),
            };
        }

        private RecommendationDTO FormRecommendation(List<Phone> phones, IDictionary<int, float> scores)
        {
            var recommendations = new Dictionary<double, Phone>();
            foreach (var phone in phones)
            {
                double score = _scoreService.GetProductScore(scores, phone.Score);
                recommendations.Add(score, phone);
            }

            var sortedRecommendations = recommendations
                .OrderByDescending(i => i.Key)
                .ToDictionary(i => i.Key, i => i.Value)
                .Values
                .ToList();

            var secondaryRecommendations = sortedRecommendations.Skip(1).Take(2).ToArray();

            return new RecommendationDTO(sortedRecommendations[0], secondaryRecommendations);
        }
    }
}
