﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
