using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AuthDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
