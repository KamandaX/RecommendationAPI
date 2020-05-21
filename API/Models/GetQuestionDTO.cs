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

        public List<AnswerDTO> Answers;

        public GetQuestionDTO(Question question)
        {
            Title = question.QuestionContent;
            Aspect = (int) question.Aspect;

            Answers = new List<AnswerDTO>();
            foreach (var option in question.QuestionOptions)
            {
                Answers.Add(new AnswerDTO(option));
            }
        }
    }
}
