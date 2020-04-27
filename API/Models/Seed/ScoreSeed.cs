namespace API.Models.Seed
{
    public static class ScoreSeed
    {
        public static void EnsureCreated(ApiContext context)
        {
            context.Scores.AddRange(
                new Score
                {
                    ID = 1,
                    PhoneID = 1,
                    ProcessingPowerScore = 9.4f,
                    MainCameraScore = 9.8f,
                    SelfieCameraScore = 9.1f,
                    StorageScore = 8.8f,
                    BatteryLifeScore = 8.6f,
                    DurabilityScore = 7.9f,
                    PopularityScore = 9.5f,
                    ScreenSizeScore = 9.8f,
                    PriceScore = 4.5f
                },
                new Score
                {
                    ID = 2,
                    PhoneID = 2,
                    ProcessingPowerScore = 8.4f,
                    MainCameraScore = 7.8f,
                    SelfieCameraScore = 7.1f,
                    StorageScore = 8.5f,
                    BatteryLifeScore = 6.8f,
                    DurabilityScore = 8.0f,
                    PopularityScore = 8.9f,
                    ScreenSizeScore = 8.8f,
                    PriceScore = 7.5f
                }
            );
        }
    }
}
