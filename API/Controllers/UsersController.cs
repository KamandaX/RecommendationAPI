using System;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [Produces(ApiContentType)]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        public UsersController(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter) :
            base(context, serializer, errorFormatter) { }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid headers!");
            }

            return NotImplementedError("Signup Not Implemented!");
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid headers!");
            }

            return NotImplementedError("Login Not Implemented!");
        }
    }
}
