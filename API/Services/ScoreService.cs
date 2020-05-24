using API.Models;
using System;
using System.Collections.Generic;

namespace API.Services
{
    public class ScoreService : IScoreService
    {
        public IDictionary<int, float> GetAspectScores(IList<QuestionOption> questionOptions)
        {
            IDictionary<int, float> aspectScores = new Dictionary<int, float>();
            IDictionary<int, int> aspectCounts = new Dictionary<int, int>();

            foreach (QuestionOption questionOption in questionOptions)
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
                throw new ArgumentNullException("weight", "Object instance is not set");

            double score = 0;
            foreach (KeyValuePair<int, float> aspectScore in aspectScores)
                score += aspectScore.Value * weight.GetScoreByID(aspectScore.Key);

            return Math.Round(score, 2);
        }
    }
}
