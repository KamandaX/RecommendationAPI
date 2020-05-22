using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public enum Aspect
    {
        ProcessingPower, MainCamera, SelfieCamera, Storage, BatteryLife, Durability, Popularity, ScreenSize, Price
    }

    public class Question
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string QuestionContent { get; set; }

        [Required]
        public Aspect Aspect { get; set; }

        [InverseProperty(nameof(QuestionOption.Question))]
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }

        [InverseProperty(nameof(QuestionOption.NextQuestion))]
        public virtual ICollection<QuestionOption> LinkedQuestionOptions { get; set; }
    }
}
