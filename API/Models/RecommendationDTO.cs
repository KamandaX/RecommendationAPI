using Newtonsoft.Json;

namespace API.Models
{
    public class RecommendationDTO
    {
        [JsonProperty("main_recommendation")]
        public Phone MainRecommendation { get; set; }

        [JsonProperty("secondary_recommendations")]
        public Phone[] SecondaryRecommendations;

        public RecommendationDTO(Phone main, Phone[] secondaryRecommendations = null)
        {
            MainRecommendation = main;
            SecondaryRecommendations = secondaryRecommendations;
        }
    }
}
