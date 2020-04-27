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
        }
    }
}
