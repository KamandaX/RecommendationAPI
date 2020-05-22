using API.Models;
using API.Models.AccountModels;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public async Task<IActionResult> Signup(RegisterModel model)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid headers!");
            }

            if (ModelState.IsValid)
            {
                var user = new UserDTO { UserName = model.Username ?? model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Created("", new
                    {
                        token = _jwt.GenerateSecurityToken(new User()
                        {
                            Username = user.UserName,
                            Email = user.Email
                        })
                    });
                }

                return BadRequest(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid headers!");
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return ApiBadRequest("User does not exist.");

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        token = _jwt.GenerateSecurityToken(new User()
                        {
                            Username = user.UserName,
                            Email = user.Email
                        })
                    });
                }

                if (result.IsLockedOut)
                {
                    return ApiBadRequest("User account locked out.");
                }
            }

            return BadRequest(ModelState);
        }
    }
}
