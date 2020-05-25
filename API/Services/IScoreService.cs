using API.Models;
using System.Collections.Generic;

namespace API.Services
{
    public interface IScoreService
    {
        IDictionary<int, float> GetAspectScores(IList<AnsweredQuestionDTO> questionOptions);
        double GetProductScore(IDictionary<int, float> aspectScores, Score weight);
    }
}
