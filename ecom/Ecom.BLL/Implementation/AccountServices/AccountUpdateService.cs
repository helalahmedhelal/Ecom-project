using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.BLL.Interfaces.AccountInterfaces;
using Ecom.BLL.Interfaces.TokenInterface;
using Ecom.Core.Dtos.AccountDtos;
using Ecom.Core.Dtos.UserCreationDto;
using Ecom.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Implementation.AccountServices
{
    public class AccountUpdateService : IAccountUpdateInterface
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ITokenInterface _token;

        public AccountUpdateService(UserManager<AppUser> userManager, ITokenInterface token)
        {
            _userManager = userManager;

            _token = token;
        }
        public async Task<UserCreationDto> UpdateAccountAsync(string Id,UpdateAccountDto updateAccountDto)
        {
            var Account =  await _userManager.FindByIdAsync(Id);

            if (Account == null){
                return null;

            }

            if(updateAccountDto.UserName != null){

                Account.UserName = updateAccountDto.UserName;
            }

            if(updateAccountDto.Email != null){

                Account.Email = updateAccountDto.Email;

            }

            var updatedAccount = await _userManager.UpdateAsync(Account);

            if(!updatedAccount.Succeeded){

                var errors = string.Join(";;; ", updatedAccount.Errors.Select(e => e.Description));

                throw new Exception($"User update failed: {errors}");
            }
            return new UserCreationDto{

                UserName = Account.UserName,

                Email = Account.Email,

                Token = _token.CreateToken(Account),
            };
            
        }
    }
}