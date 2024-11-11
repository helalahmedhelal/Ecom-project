using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Core.Dtos.AccountDtos
{
    public class UpdateAccountDto
    {
        
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
    }
}