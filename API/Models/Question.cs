using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public enum Aspect
    {
        ProcessingPower, MainCamera, SelfieCamera, Storage, BatteryLife, Durability, Popularity, ScreenSize, Price
    }

    public class Question
    {
        [Key]
        [JsonProperty("id")]
        public int ID { get; set; }

        [Required]
        [JsonProperty("question_content")]
        public string QuestionContent { get; set; }

        [Required]
        [JsonProperty("aspect")]
        public Aspect Aspect { get; set; }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
