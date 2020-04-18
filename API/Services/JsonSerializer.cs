using Newtonsoft.Json;

namespace API.Services
{
    public class JsonSerializer : Iserializer
    {
        public string Encode<T>(T obj)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public T Decode<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
