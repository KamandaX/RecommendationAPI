using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Phone
    {
        [Key]
        [JsonProperty("id")] 
        public int ID { get; set; }

        
        [Required]
        [JsonProperty("manufacturer")] 
        public string Manufacturer { get; set; }
        
        [Required]
        [JsonProperty("model_name")] 
        public string ModelName { get; set; }
       
        [Required]
        [JsonProperty("display_resolution_horizontal")] 
        public int DisplayResolutionHorizontal { get; set; }
        
        [Required]
        [JsonProperty("display_resolution_vertical")] 
        public int DisplayResolutionVertical { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("price")] 
        public decimal Price { get; set; }
        
        [Required]
        [JsonProperty("screen_size")] 
        public float ScreenSize { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [JsonProperty("launch_date")] 
        public DateTime LaunchDate { get; set; }


        [JsonProperty("protection_rating")] 
        public float ProtectionRating { get; set; }
        
        [Required]
        [JsonProperty("processor")] 
        public string Processor { get; set; }
        
        [Required]
        [JsonProperty("storage")] 
        public int Storage { get; set; }
        
        [Required]
        [JsonProperty("ram")] 
        public int Ram { get; set; }

        [Required]
        [JsonProperty("battery_size")] 
        public int BatterySize { get; set; }

        public virtual ICollection<Camera> Cameras { get; set; }

        public virtual Score Score { get; set; }
    }
}
