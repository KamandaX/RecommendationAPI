using System.Linq;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

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

        protected string ApiBadRequest()
        {
            return ErrorFormatter.FormatError(400, "Invalid Headers");
        }
    }
}
