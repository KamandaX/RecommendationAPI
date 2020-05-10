using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces(ApiContentType)]
    [ApiController]
    public class QuestionsController : ApiControllerBase
    {
        public QuestionsController(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter) :
            base(context, serializer, errorFormatter) { }

        [HttpGet("{id=0}")]
        public async Task<ActionResult<string>> GetQuestion(int id)
        {
            if (!IsValidApiRequest())
            {
                return ApiBadRequest("Invalid headers!");
            }

            try
            {
                var question = id == 0 ? 
                    await Context.Questions.Include(i => i.QuestionOptions).FirstOrDefaultAsync()
                        .ConfigureAwait(false) :
                    await Context.Questions.Include(i => i.QuestionOptions).SingleOrDefaultAsync(i => i.ID == id)
                        .ConfigureAwait(false);

                if (question == default(Question))
                    return ApiNotFound("Question does not exist!");

                return Ok(question);
            }
            catch (Exception ex)
            {
                return InternalServerError("Error in retrieving a question!", ex.Message);
            }
        }
    }
}
