using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecommendationController : ApiControllerBase
    {
        public RecommendationController(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter) :
            base(context, serializer, errorFormatter) { }

        [HttpPost]
        public ActionResult<string> GetQuizMessage(AnsweredQuestionDTO[] questions)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid Headers!");
            }

            return NotImplementedError("Recommendation method not implemented!");
        }
    }
}
