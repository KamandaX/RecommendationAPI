using API.Models;
using API.Services;
using System.Collections.Generic;
using Xunit;

namespace API.Tests
{
    public class ScoreTest
    {
        [Fact]
        public void GetAspectScores_InputIsAnswers_AspectScores()
        {
            var answers = new List<AnsweredQuestionDTO>()
            {
                new AnsweredQuestionDTO 
                {
                    Aspect = 1,
                    Multiplier = 0.3f
                },
                new AnsweredQuestionDTO
                {
                    Aspect = 1,
                    Multiplier = 0.2f
                },
                new AnsweredQuestionDTO
                {
                    Aspect = 2,
                    Multiplier = 0.1f
                }

            };

            var scoreService = new ScoreService();
            var scores = scoreService.GetAspectScores(answers);
            Assert.Equal(0.25f, scores[1], 1);
            Assert.Equal(0.1f, scores[2], 1);
        }                             
    }
}
