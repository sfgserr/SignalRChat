using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Quickstart.UI
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set;}
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
