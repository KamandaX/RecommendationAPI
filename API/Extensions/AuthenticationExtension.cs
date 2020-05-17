using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Middleware
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var jwtConfig = config.GetSection("Jwt");
            var secret = jwtConfig.GetSection("SecretKey").Value;
            var validIssuer = jwtConfig.GetSection("ValidIssuer").Value;
            var validAudience = jwtConfig.GetSection("ValidAudience").Value;

            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience
                };
            });

            return services;
        }
    }
}
