using System;

namespace API.Models.Seed
{
    public static class PhoneSeed
    {
        public static void EnsureCreated(ApiContext context)
        {
            context.Phones.AddRange(
                new Phone
                {
                    ID = 1,
                    Manufacturer = "Samsung",
                    ModelName = "Galaxy S20",
                    DisplayResolutionHorizontal = 1440,
                    DisplayResolutionVertical = 3200,
                    Price = 999M,
                    LaunchDate = DateTime.Parse("2020-2-11"),
                    ScreenSize = 6.2f,
                    ProtectionRating = 8.5f,
                    Processor = "Octa-core (2x2.73 GHz Mongoose M5 & 2x2.50 GHz Cortex-A76 & 4x2.0 GHz Cortex-A55) - Global\nOcta-core (1x2.84 GHz Kryo 585 & 3x2.42 GHz Kryo 585 & 4x1.8 GHz Kryo 585) - USA",
                    Storage = 128,
                    Ram = 8,
                    BatterySize = 4000
                },
                new Phone
                {
                    ID = 2,
                    Manufacturer = "Samsung",
                    ModelName = "Galaxy S9",
                    DisplayResolutionHorizontal = 1440,
                    DisplayResolutionVertical = 2960,
                    Price = 299M,
                    LaunchDate = DateTime.Parse("2018-3-1"),
                    ScreenSize = 5.8f,
                    ProtectionRating = 8.0f,
                    Processor = "Octa-core (4x2.7 GHz Mongoose M3 & 4x1.8 GHz Cortex-A55) - EMEA\nOcta-core (4x2.8 GHz Kryo 385 Gold & 4x1.7 GHz Kryo 385 Silver) - USA/LATAM, China",
                    Storage = 128,
                    Ram = 4,
                    BatterySize = 3000
                }
            );
        }
    }
}
