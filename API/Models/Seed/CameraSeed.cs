namespace API.Models.Seed
{
    public static class CameraSeed
    {
        public static void EnsureCreated(ApiContext context)
        {
            context.Cameras.AddRange(
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
        }
    }
}
