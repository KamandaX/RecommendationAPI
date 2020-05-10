using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/Quiz")]
    [Produces(ApiContentType)]
    [ApiController]
    public class QuizController : ApiControllerBase
    {
        public QuizController(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter) :
            base(context, serializer, errorFormatter) { }

        [HttpGet]
        public ActionResult<string> GetQuizMessage()
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid Headers!");
            }

            var quiz = new Quiz {Data = new Data {Message = "Hello from QuizAPI!"}};
            return Ok(quiz);
        }
    }
}
