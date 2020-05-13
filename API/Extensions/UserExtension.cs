using API.Models;
using System;
using System.Security.Claims;

namespace API.Extensions
{
    public static class UserExtension
    {
        public static User GetUserData(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return new User
            {
                Email = principal.FindFirst(ClaimTypes.Email)?.Value,
                Username = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
            };
        }
    }
}
