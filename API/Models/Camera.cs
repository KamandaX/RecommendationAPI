using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public enum Side
    {
        Main, Selfie
    }

    public class Camera
    {
        [Key]
        [JsonProperty("id")]
        public int ID { get; set; }

        [Required]
        [JsonProperty("phone_id")]
        public int PhoneID { get; set; }
        public virtual Phone Phone { get; set; }

        [Required]
        [JsonProperty("side")]
        public Side Side { get; set; }

        [Required]
        [JsonProperty("megapixels")]
        public int Megapixels { get; set; }

        [JsonProperty("f-number")]
        public float FNumber { get; set; }


    }
}
