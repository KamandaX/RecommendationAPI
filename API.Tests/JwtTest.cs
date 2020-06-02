using API.Models;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Xunit;

namespace API.Tests
{
    public class JwtTest
    {
        private IConfiguration _config;

        public JwtTest()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(Configuration);
        }

        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }

        [Fact]
        public void GenerateSecurityToken_InputEmailUsername_EqualsClaim()
        {
            var jwt = new JwtService(Configuration);
            var token = jwt.GenerateSecurityToken(new User { Email = "johndoe@example.com", Username = "foo" });

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            Assert.Equal("johndoe@example.com", tokenS.Claims.First(claim => claim.Type == "email").Value);
            Assert.Equal("foo", tokenS.Claims.First(claim => claim.Type == "unique_name").Value);
        }
    }
}
