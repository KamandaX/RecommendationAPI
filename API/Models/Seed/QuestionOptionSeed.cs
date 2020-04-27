namespace API.Models.Seed
{
    public static class QuestionOptionSeed
    {
        public static void EnsureCreated(ApiContext context)
        {
            context.QuestionOptions.AddRange(
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
        }
    }
}
