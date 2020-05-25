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

        public float GetScoreByID(AspectType ID)
        {
            return ID switch
            {
                AspectType.ProcessingPowerScore => ProcessingPowerScore,
                AspectType.MainCameraScore => MainCameraScore,
                AspectType.SelfieCameraScore => SelfieCameraScore,
                AspectType.StorageScore => StorageScore,
                AspectType.BatteryLifeScore => BatteryLifeScore,
                AspectType.DurabilityScore => DurabilityScore,
                AspectType.PopularityScore => PopularityScore,
                AspectType.ScreenSizeScore => ScreenSizeScore,
                AspectType.PriceScore => PriceScore,
                _ => 0,
            };
        }
    }
}
