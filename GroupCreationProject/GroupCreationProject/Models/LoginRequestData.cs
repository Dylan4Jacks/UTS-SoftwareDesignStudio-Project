using System.ComponentModel.DataAnnotations;

namespace GroupCreationProject.Models
{
    public class LoginRequestData
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
