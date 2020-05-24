using Microsoft.AspNetCore.Identity;
using System;

namespace API.Models.Seed
{
    public static class UserSeed
    {
        public static void EnsureCreated(ApiContext context, UserManager<UserDTO> userManager)
        {
            if (context == null || userManager == null)
                return;

            var user = new UserDTO
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "TestUser",
                NormalizedUserName = "TESTUSER",
                Email = "TestUser@mobite.com",
                NormalizedEmail = "TESTUSER@MOBITE.COM",
                EmailConfirmed = false,
                SecurityStamp = "CHGA7QF2UKDH4OU3OKLHM3G2MXSRCFHS",
                ConcurrencyStamp = "0004fefb-68e5-48b7-ad69-fb4897635ec9"
            };
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "Pass#123");

            var user2 = new UserDTO
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "TestUser2",
                NormalizedUserName = "TESTUSER2",
                Email = "TestUser2@mobite.com",
                NormalizedEmail = "TESTUSER2@MOBITE.COM",
                EmailConfirmed = true,
                SecurityStamp = "MGXLDOCUZDEBWPLECV4DS3FHGQTVDKHN",
                ConcurrencyStamp = "410a48c2-8088-4e5e-80d9-2acd2bbbde57"
            };
            user2.PasswordHash = userManager.PasswordHasher.HashPassword(user2, "Pass#456");

            context.Users.AddRange(user, user2);
        }
    }
}
