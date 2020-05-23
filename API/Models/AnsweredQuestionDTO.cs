using Newtonsoft.Json;

namespace API.Models
{
    public class AnsweredQuestionDTO
    {
        [JsonProperty("aspect")]
        public int Aspect { get; set; }

        [JsonProperty("multiplier")]
        public float Multiplier { get; set; }
    }
}
