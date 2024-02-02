using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace User.Grpc.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
