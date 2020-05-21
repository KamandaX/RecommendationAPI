using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class QuestionOption
    {
        [Key]
        [JsonIgnore]
        public int ID { get; set; }

        [Required]
        [JsonIgnore]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        [Required]
        [JsonProperty("answer")]
        public string OptionContent { get; set; }

        [DisplayFormat(NullDisplayText = "")]
        [JsonProperty("img_url")]
        public string PictureLink { get; set; }

        [Required]
        [JsonIgnore]
        public float QuestionMultiplier { get; set; }

        [JsonProperty("next_question_id")]
        public int? NextQuestionID { get; set; }
        public virtual Question NextQuestion { get; set; }
    }
}
