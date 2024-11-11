using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.BLL.Interfaces.AccountInterfaces
{
    public interface IAccountDeleteInterface
    {
        public Task<bool> DeleteAccountAsync(string Id);
    }
}