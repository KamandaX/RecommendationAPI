using Newtonsoft.Json;
using System;

namespace API.Models
{
    public class QuestionOptionDTO
    {
        [JsonProperty("answer")]
        public string AnswerText { get; }

        [JsonProperty("img_url")]
        public string ImgUrl { get; }

        [JsonProperty("next_question_id")]
        public int? NextQuestionId { get; }

        [JsonProperty("multiplier")]
        public float Multiplier { get; }

        public QuestionOptionDTO(QuestionOption answer)
        {
            AnswerText = answer.OptionContent;
            ImgUrl = answer.PictureLink ?? Environment.GetEnvironmentVariable("ASPNETCORE_IMGFALLBACKURL");
            NextQuestionId = answer.NextQuestionID;
            Multiplier = answer.QuestionMultiplier;
        }
    }
}
