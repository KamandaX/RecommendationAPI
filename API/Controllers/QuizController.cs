using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/v1/Quiz")]
    [ApiController]
    public class QuizController : ApiControllerBase
    {
        public QuizController(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter) :
            base(context, serializer, errorFormatter)
        { }

        [HttpGet]
        public ActionResult<string> GetQuizMessage()
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid Headers!");
            }

            var quiz = new Quiz { Data = new Data { Message = "Hello from QuizAPI!" } };
            try
            {
                string json = Serializer.Encode(quiz);
                return Ok(json);
            }
            catch (Exception ex)
            {
                return InternalServerError("Json error!",ex.Message);
            }
        }
    }
}
