using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.DAL.Models;

namespace Ecom.BLL.Interfaces.TokenInterface
{
    public interface ITokenInterface
    {
        string CreateToken(AppUser user);
    }
}