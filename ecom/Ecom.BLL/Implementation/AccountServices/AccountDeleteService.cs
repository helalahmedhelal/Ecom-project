using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.BLL.Interfaces.AccountInterfaces;
using Ecom.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Implementation.AccountServices
{
    public class AccountDeleteService : IAccountDeleteInterface
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountDeleteService(UserManager<AppUser> userManager){
            _userManager = userManager;

        }

        public async Task<bool> DeleteAccountAsync(string Id)
        {
            var Account = await _userManager.FindByIdAsync(Id);
            if (Account == null){

                return false;
            }
            var AccountDelete = await _userManager.DeleteAsync(Account);

            return AccountDelete.Succeeded;
        }    
    }
}