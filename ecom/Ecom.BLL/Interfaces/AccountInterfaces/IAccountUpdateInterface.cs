using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Core.Dtos.AccountDtos;
using Ecom.Core.Dtos.UserCreationDto;
using Ecom.DAL.Models;

namespace Ecom.BLL.Interfaces.AccountInterfaces
{
    public interface IAccountUpdateInterface
    {
        public Task<UserCreationDto> UpdateAccountAsync(string Id,UpdateAccountDto updateAccountDto);
    }
}