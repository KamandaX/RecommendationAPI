using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class QuestionOption
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int QuestionID { get; set; }

        public virtual Question Question { get; set; }

        [Required]
        public string OptionContent { get; set; }

        [DisplayFormat(NullDisplayText = "")]
        public string PictureLink { get; set; }

        [Required]
        public float QuestionMultiplier { get; set; }

        public int? NextQuestionID { get; set; }

        public virtual Question NextQuestion { get; set; }
    }
}
