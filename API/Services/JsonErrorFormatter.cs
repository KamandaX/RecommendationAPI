using API.Models;

namespace API.Services
{
    public class JsonErrorFormatter : IErrorFormatter
    {
        private readonly Iserializer _serializer = new JsonSerializer();

        public string FormatError(int code, string message = null, string details = null)
        {
            var errorObj = new Error
            {
                Details = details ?? "",
                Title = message ?? "",
                Type = code
            };
            return _serializer.Encode(errorObj);
        }
    }
}
