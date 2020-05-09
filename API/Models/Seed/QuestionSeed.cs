namespace API.Models.Seed
{
    public static class QuestionSeed
    {
        public static void EnsureCreated(ApiContext context)
        {
            context.Questions.AddRange(
                new Question
                {
                    ID = 1,
                    QuestionContent = "How much are you willing to spend?",
                    Aspect = Aspect.Price
                },
                new Question
                {
                    ID = 2,
                    QuestionContent = "How much do you plan to use your phone for photography?",
                    Aspect = Aspect.MainCamera
                },
                new Question
                {
                    ID = 3,
                    QuestionContent = "How often do you plan to play video games on your phone?",
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
                    QuestionContent = "What files will you store on your phone?",
                    Aspect = Aspect.Storage
                },
                new Question
                {
                    ID = 6,
                    QuestionContent = "Will you take photos in low lighting?",
                    Aspect = Aspect.MainCamera
                },
                new Question
                {
                    ID = 7,
                    QuestionContent = "Do you want the camera to be able to zoom in a lot?",
                    Aspect = Aspect.MainCamera
                },
                new Question
                {
                    ID = 8,
                    QuestionContent = "Do you need to take photos quickly?",
                    Aspect = Aspect.MainCamera
                },
                new Question
                {
                    ID = 9,
                    QuestionContent = "How often do you take selfies?",
                    Aspect = Aspect.SelfieCamera
                }
            );
        }
    }
}
