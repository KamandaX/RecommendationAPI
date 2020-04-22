using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class QuestionOption
    {
        [Key]
        [JsonProperty("id")]
        public int ID { get; set; }

        [Required]
        [JsonProperty("question_id")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        [Required]
        [JsonProperty("option_content")]
        public string OptionContent { get; set; }

        [DisplayFormat(NullDisplayText = "")]
        [JsonProperty("picture_link")]
        public string? PictureLink { get; set; }

        [Required]
        [JsonProperty("question_multiplier")]
        public float QuestionMultiplier { get; set; }
    }
}
