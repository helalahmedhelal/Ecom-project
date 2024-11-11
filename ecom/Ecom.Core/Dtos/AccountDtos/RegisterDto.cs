using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Core.Dtos.AccountDtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }=string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }= string.Empty;
    }
}