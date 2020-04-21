using Newtonsoft.Json;

namespace API.Models
{
    public class Quiz
    {
        [JsonProperty("data")] public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("message")] public string Message { get; set; }
    }
}
