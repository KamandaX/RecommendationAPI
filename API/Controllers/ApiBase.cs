using System.Linq;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected readonly Iserializer Serializer;
        protected readonly IErrorFormatter ErrorFormatter;

        private const string ApiHeader = "X-Api-Request";

        public ApiControllerBase(Iserializer serializer, IErrorFormatter errorFormatter)
        {
            Serializer = serializer;
            ErrorFormatter = errorFormatter;
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

        protected string ApiBadRequest()
        {
            return ErrorFormatter.FormatError(400, "Invalid Headers");
        }
    }
}
