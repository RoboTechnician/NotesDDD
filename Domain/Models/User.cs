using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public const int EmailLength = 255;
        public const int PasswordLength = 64;
        public const int PasswordMinLength = 6;

        public IEnumerable<Note> Notes { get; set; }
    }
}
