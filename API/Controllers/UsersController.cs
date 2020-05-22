using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [Produces(ApiContentType)]
    [ApiController]
    [Authorize]
    public class UsersController : ApiControllerBase
    {
        private readonly UserManager<UserDTO> _userManager;
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly JwtService _jwt;
        public UsersController(
            ApiContext context,
            Iserializer serializer,
            IErrorFormatter errorFormatter,
            IConfiguration config,
            UserManager<UserDTO> userManager,
            SignInManager<UserDTO> signInManager) :
            base(context, serializer, errorFormatter)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = new JwtService(config);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Signup(AuthDTO model)
        {
            if (!IsValidApiRequest())
                return ApiBadRequest("Invalid headers!");

            var user = new UserDTO { UserName = model.Username ?? model.Email, Email = model.Email };

            foreach(var validator in _userManager.PasswordValidators)
            {
                var res = await validator.ValidateAsync(_userManager, null, model.Password);
                if (!res.Succeeded)
                    return ApiBadRequest(res.Errors.First().Description);
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return ApiBadRequest(result.Errors.First().Description);

            return Created("", new
            {
                token = _jwt.GenerateSecurityToken(new User()
                {
                    Username = user.UserName,
                    Email = user.Email
                })
            });

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthDTO model)
        {
            if (!IsValidApiRequest())
                return ApiBadRequest("Invalid headers!");

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return ApiBadRequest("User does not exist.");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, lockoutOnFailure: false);
            if (result.IsLockedOut)
                return ApiBadRequest("User account locked out.");

            if (!result.Succeeded)
                return ApiBadRequest("Invalid username or password.");

            return Ok(new
            {
                token = _jwt.GenerateSecurityToken(new User()
                {
                    Username = user.UserName,
                    Email = user.Email
                })
            });
        }
    }
}
