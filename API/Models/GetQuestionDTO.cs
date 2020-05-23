using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Models
{
    public class GetQuestionDTO
    {
        [JsonProperty("title")] 
        public string Title { get; set; }

        [JsonProperty("aspect")] 
        public int Aspect { get; set; }

        public List<QuestionOptionDTO> Answers;

        public GetQuestionDTO(Question question)
        {
            Title = question.QuestionContent;
            Aspect = (int) question.Aspect;

            Answers = new List<QuestionOptionDTO>();
            foreach (var option in question.QuestionOptions)
            {
                Answers.Add(new QuestionOptionDTO(option));
            }
        }
    }
}
