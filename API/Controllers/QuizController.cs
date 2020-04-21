using System;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/Quiz")]
    [ApiController]
    public class QuizController : ApiControllerBase
    {
        public QuizController(Iserializer serializer, IErrorFormatter errorFormatter) :
            base(serializer, errorFormatter) { }

        [HttpGet]
        public string GetQuizMessage()
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest();
            }

            var quiz = new Quiz {Data = new Data {Message = "Hello from QuizAPI!"}};
            try
            {
                string json = Serializer.Encode(quiz);
                return json;
            }
            catch (Exception ex)
            {
                return ErrorFormatter.FormatError(500, "Json Error", ex.Message);
            }
        }
    }
}
