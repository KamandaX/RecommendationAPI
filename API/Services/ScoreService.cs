using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class ScoreService : IScoreService
    {
        public IDictionary<int, float> GetAspectScores(IList<QuestionOption> questionOptions)
        {
            var aspectScores = new Dictionary<int, float>();
            var aspectCounts = new Dictionary<int, int>();

            foreach (var questionOption in questionOptions)
            {
                if (questionOption.Question == null)
                    throw new ArgumentException("Question option does not include the Question object");

                int aspectID = (int)questionOption.Question.Aspect;
                if (aspectScores.ContainsKey(aspectID))
                {
                    aspectScores[aspectID] += questionOption.QuestionMultiplier;
                    aspectCounts[aspectID]++;
                }
                else
                {
                    aspectScores[aspectID] = questionOption.QuestionMultiplier;
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
                current + aspectScore.Value * weight.GetScoreByID(aspectScore.Key));

            return Math.Round(score, 2);
        }
    }
}
