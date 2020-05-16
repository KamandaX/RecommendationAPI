using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Key] 
        [JsonProperty("id")] 
        public int ID { get; set; }

        [Required] 
        [JsonProperty("email")] 
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("password")] 
        public string Password { get; set; }
    }
}
