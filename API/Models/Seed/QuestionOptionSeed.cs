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
                    OptionContent = "I'm poor",
                    QuestionMultiplier = 0.3f,
                    NextQuestionID = 2
                },
                new QuestionOption
                {
                    ID = 2,
                    QuestionID = 1,
                    OptionContent = "€400 is fine",
                    QuestionMultiplier = 0.5f,
                    NextQuestionID = 2
                },
                new QuestionOption
                {
                    ID = 3,
                    QuestionID = 1,
                    OptionContent = "Top notch pls",
                    QuestionMultiplier = 1.0f,
                    NextQuestionID = 2
                },
                new QuestionOption
                {
                    ID = 4,
                    QuestionID = 2,
                    OptionContent = "Never",
                    QuestionMultiplier = 0.0f,
                    NextQuestionID = 3
                },
                new QuestionOption
                {
                    ID = 5,
                    QuestionID = 2,
                    OptionContent = "Occasionally",
                    QuestionMultiplier = 0.2f,
                    NextQuestionID = 6
                },
                new QuestionOption
                {
                    ID = 6,
                    QuestionID = 2,
                    OptionContent = "All the time",
                    QuestionMultiplier = 0.4f,
                    NextQuestionID = 6
                },
                new QuestionOption
                {
                    ID = 7,
                    QuestionID = 3,
                    OptionContent = "Never",
                    QuestionMultiplier = 0.0f,
                    NextQuestionID = 4
                },
                new QuestionOption
                {
                    ID = 8,
                    QuestionID = 3,
                    OptionContent = "Occasionally",
                    QuestionMultiplier = 0.5f,
                    NextQuestionID = 4
                },
                new QuestionOption
                {
                    ID = 9,
                    QuestionID = 3,
                    OptionContent = "All the time",
                    QuestionMultiplier = 1.0f,
                    NextQuestionID = 4
                },
                new QuestionOption
                {
                    ID = 10,
                    QuestionID = 4,
                    OptionContent = "Not at all",
                    QuestionMultiplier = 0.0f,
                    NextQuestionID = 5
                },
                new QuestionOption
                {
                    ID = 11,
                    QuestionID = 4,
                    OptionContent = "Maybe",
                    QuestionMultiplier = 0.5f,
                    NextQuestionID = 5
                },
                new QuestionOption
                {
                    ID = 12,
                    QuestionID = 4,
                    OptionContent = "I live in danger",
                    QuestionMultiplier = 1.0f,
                    NextQuestionID = 5
                },
                new QuestionOption
                {
                    ID = 13,
                    QuestionID = 5,
                    OptionContent = "Only the essential stuff",
                    QuestionMultiplier = 0.0f,
                },
               new QuestionOption
               {
                   ID = 14,
                   QuestionID = 5,
                   OptionContent = "Some apps and photos",
                   QuestionMultiplier = 0.5f
               },
               new QuestionOption
               {
                   ID = 15,
                   QuestionID = 5,
                   OptionContent = "All kinds of files and media",
                   QuestionMultiplier = 1.0f
               },
               new QuestionOption
               {
                   ID = 16,
                   QuestionID = 6,
                   OptionContent = "No",
                   QuestionMultiplier = 0.0f,
                   NextQuestionID = 7
               },
               new QuestionOption
               {
                   ID = 17,
                   QuestionID = 6,
                   OptionContent = "Maybe",
                   QuestionMultiplier = 0.1f,
                   NextQuestionID = 7
               },
               new QuestionOption
               {
                   ID = 18,
                   QuestionID = 6,
                   OptionContent = "Most certainly",
                   QuestionMultiplier = 0.2f,
                   NextQuestionID = 7
               },
               new QuestionOption
               {
                   ID = 19,
                   QuestionID = 7,
                   OptionContent = "No",
                   QuestionMultiplier = 0.0f,
                   NextQuestionID = 8
               },
               new QuestionOption
               {
                   ID = 20,
                   QuestionID = 7,
                   OptionContent = "Maybe",
                   QuestionMultiplier = 0.1f,
                   NextQuestionID = 8
               },
               new QuestionOption
               {
                   ID = 21,
                   QuestionID = 7,
                   OptionContent = "Most certainly",
                   QuestionMultiplier = 0.2f,
                   NextQuestionID = 8
               },
               new QuestionOption
               {
                   ID = 22,
                   QuestionID = 8,
                   OptionContent = "No",
                   QuestionMultiplier = 0.0f,
                   NextQuestionID = 9
               },
               new QuestionOption
               {
                   ID = 23,
                   QuestionID = 8,
                   OptionContent = "Maybe",
                   QuestionMultiplier = 0.1f,
                   NextQuestionID = 9
               },
               new QuestionOption
               {
                   ID = 24,
                   QuestionID = 8,
                   OptionContent = "Most certainly",
                   QuestionMultiplier = 0.2f,
                   NextQuestionID = 9
               },
               new QuestionOption
               {
                   ID = 25,
                   QuestionID = 9,
                   OptionContent = "Never",
                   QuestionMultiplier = 0.0f,
                   NextQuestionID = 3
               },
               new QuestionOption
               {
                   ID = 26,
                   QuestionID = 9,
                   OptionContent = "Sometimes",
                   QuestionMultiplier = 0.5f,
                   NextQuestionID = 3
               },
               new QuestionOption
               {
                   ID = 27,
                   QuestionID = 9,
                   OptionContent = "All the time",
                   QuestionMultiplier = 1.0f,
                   NextQuestionID = 3
               }
            );
        }
    }
}
