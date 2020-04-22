using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SeedData
    {
        private readonly ApiContext _context;

        public SeedData(ApiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            var testPhone = _context.Phones.FirstOrDefault(b => b.ID == 1);
            if (testPhone != null)
                return;

            #region PhoneSeed
            _context.Phones.AddRange(
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
            #endregion

            #region CameraSeed
            _context.Cameras.AddRange(
                new Camera
                {
                    ID = 1,
                    PhoneID = 1,
                    Side = Side.Main,
                    Megapixels = 12,
                    FNumber = 1.8f
                },
                new Camera
                {
                    ID = 2,
                    PhoneID = 1,
                    Side = Side.Main,
                    Megapixels = 64,
                    FNumber = 2.0f
                },
                new Camera
                {
                    ID = 3,
                    PhoneID = 1,
                    Side = Side.Main,
                    Megapixels = 12,
                    FNumber = 2.2f
                },
                new Camera
                {
                    ID = 4,
                    PhoneID = 1,
                    Side = Side.Main,
                    Megapixels = 10,
                    FNumber = 2.2f
                },
                new Camera
                {
                    ID = 5,
                    PhoneID = 2,
                    Side = Side.Main,
                    Megapixels = 12,
                    FNumber = 2.4f
                },
                new Camera
                {
                    ID = 6,
                    PhoneID = 2,
                    Side = Side.Main,
                    Megapixels = 8,
                    FNumber = 1.7f
                }
            );
            #endregion

            #region ScoreSeed
            _context.Scores.AddRange(
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
            #endregion

            #region QuestionSeed
            _context.Questions.AddRange(
                new Question
                {
                    ID = 1,
                    QuestionContent = "How much are you willing to spend?",
                    Aspect = Aspect.Price
                },
                new Question
                {
                    ID = 2,
                    QuestionContent = "Do you want to use you phone for photography?",
                    Aspect = Aspect.MainCamera
                },
                new Question
                {
                    ID = 3,
                    QuestionContent = "Do you want to play video games on your phone?",
                    Aspect = Aspect.ProcessingPower
                },
                new Question
                {
                    ID = 4,
                    QuestionContent = "Will your phone be exposed to harsh environments?",
                    Aspect = Aspect.Durability
                },
                new Question
                {
                    ID = 5,
                    QuestionContent = "Are you planning to stroe lots of files?",
                    Aspect = Aspect.Storage
                }
            );
            #endregion

            #region QuestionOptionSeed
            _context.QuestionOptions.AddRange(
                new QuestionOption
                {
                    ID = 1,
                    QuestionID = 1,
                    OptionContent = "range",
                    QuestionMultiplier = 0.5f
                },
                new QuestionOption
                {
                    ID = 2,
                    QuestionID = 2,
                    OptionContent = "stars",
                    QuestionMultiplier = 0.5f
                },
                new QuestionOption
                {
                    ID = 3,
                    QuestionID = 3,
                    OptionContent = "stars",
                    QuestionMultiplier = 0.5f
                },
                new QuestionOption
                {
                    ID = 4,
                    QuestionID = 4,
                    OptionContent = "stars",
                    QuestionMultiplier = 0.5f
                },
                new QuestionOption
                {
                    ID = 5,
                    QuestionID = 5,
                    OptionContent = "stars",
                    QuestionMultiplier = 0.5f
                }
            );
            #endregion

            _context.SaveChanges();
        }
    }
}
