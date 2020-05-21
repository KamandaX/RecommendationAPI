using System;
using Newtonsoft.Json;

namespace API.Models
{
    public class AnswerDTO
    {
        [JsonProperty("answer")] 
        public string AnswerText { get; }

        [JsonProperty("img_url")] 
        public string ImgUrl { get; }

        [JsonProperty("next_question_id")] 
        public int? NextQuestionId { get; }

        [JsonProperty("multiplier")] 
        public float Multiplier { get; }

        public AnswerDTO(QuestionOption answer)
        {
            AnswerText = answer.OptionContent;
            ImgUrl = answer.PictureLink ?? Environment.GetEnvironmentVariable("ASPNETCORE_IMGFALLBACKURL");
            NextQuestionId = answer.NextQuestionID;
            Multiplier = answer.QuestionMultiplier;
        }
    }
}
