using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        private const string ApiHeader = "X-Api-Request";

        protected ApiContext Context { get; }

        protected IErrorFormatter ErrorFormatter { get; }

        protected Iserializer Serializer { get; }

        public ApiControllerBase(ApiContext context, Iserializer serializer, IErrorFormatter errorFormatter)
        {
            Serializer = serializer;
            ErrorFormatter = errorFormatter;
            Context = context;
        }

        protected bool IsValidApiRequest()
        {
            Request.Headers.TryGetValue(ApiHeader, out var headers);
            if (headers.Count != 1 || string.IsNullOrWhiteSpace(headers.FirstOrDefault()))
            {
                return false;
            }

            return headers == "true";
        }

        protected BadRequestObjectResult ApiBadRequest(string message)
        {
            return BadRequest(ErrorFormatter.FormatError(400, message));
        }

        protected NotFoundObjectResult ApiNotFound(string message)
        {
            return NotFound(ErrorFormatter.FormatError(404, message));
        }

        protected ObjectResult InternalServerError(string message, string details = null)
        {
            string errorObject = ErrorFormatter.FormatError(500, message, details);
            return StatusCode(500, errorObject);
        }
    }
}
