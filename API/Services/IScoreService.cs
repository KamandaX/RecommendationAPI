using API.Models;
using System.Collections.Generic;

namespace API.Services
{
    public interface IScoreService
    {
        IDictionary<int, float> GetAspectScores(IList<QuestionOption> questionOptions);
        double GetProductScore(IDictionary<int, float> aspectScores, Score weight);
    }
}
