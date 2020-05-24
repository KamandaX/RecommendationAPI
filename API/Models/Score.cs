using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Score
    {
        [Key]
        [JsonProperty("id")]
        public int ID { get; set; }

        [Required]
        [JsonProperty("phone_id")]
        public int PhoneID { get; set; }
        public virtual Phone Phone { get; set; }

        [JsonProperty("processing_power_scr")]
        public float ProcessingPowerScore { get; set; }

        [JsonProperty("main_camera_scr")]
        public float MainCameraScore { get; set; }

        [JsonProperty("selfie_camera_scr")]
        public float SelfieCameraScore { get; set; }

        [JsonProperty("storage_scr")]
        public float StorageScore { get; set; }

        [JsonProperty("battery_life_scr")]
        public float BatteryLifeScore { get; set; }

        [JsonProperty("durability_scr")]
        public float DurabilityScore { get; set; }

        [JsonProperty("popularity_scr")]
        public float PopularityScore { get; set; }

        [JsonProperty("screen_size_scr")]
        public float ScreenSizeScore { get; set; }

        [JsonProperty("price_scr")]
        public float PriceScore { get; set; }

        public float GetScoreByID(int ID)
        {
            return ID switch
            {
                0 => ProcessingPowerScore,
                1 => MainCameraScore,
                2 => SelfieCameraScore,
                3 => StorageScore,
                4 => BatteryLifeScore,
                5 => DurabilityScore,
                6 => PopularityScore,
                7 => ScreenSizeScore,
                8 => PriceScore,
                _ => 0,
            };
        }
    }
}
