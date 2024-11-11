using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Core.Dtos.UserCreationDto
{
    public class UserCreationDto
    {
        public string UserName { get; set; }="";

        public string Email { get; set;}="";

        public string Token{ get; set;}="";
    }
}