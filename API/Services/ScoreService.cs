using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class ScoreService : IScoreService
    {
        public IDictionary<int, float> GetAspectScores(IList<AnsweredQuestionDTO> questionOptions)
        {
            var aspectScores = new Dictionary<int, float>();
            var aspectCounts = new Dictionary<int, int>();

            foreach (var questionOption in questionOptions)
            {
                int aspectID = questionOption.Aspect;
                if (aspectScores.ContainsKey(aspectID))
                {
                    aspectScores[aspectID] += questionOption.Multiplier;
                    aspectCounts[aspectID]++;
                }
                else
                {
                    aspectScores[aspectID] = questionOption.Multiplier;
                    aspectCounts[aspectID] = 1;
                }
            }

            foreach (int aspectID in aspectCounts.Keys)
                aspectScores[aspectID] /= aspectCounts[aspectID];

            return aspectScores;
        }

        public double GetProductScore(IDictionary<int, float> aspectScores, Score weight)
        {
            if (weight == null)
                throw new ArgumentNullException(nameof(weight), "Object instance is not set");

            double score = aspectScores.Aggregate<KeyValuePair<int, float>, double>(0, (current, aspectScore) =>
                current + aspectScore.Value * weight.GetScoreByID((AspectType) aspectScore.Key));

            return Math.Round(score, 2);
        }
    }
}
