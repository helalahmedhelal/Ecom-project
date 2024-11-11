using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.BLL.Interfaces.AccountInterfaces;
using Ecom.BLL.Interfaces.TokenInterface;
using Ecom.Core.Dtos.AccountDtos;
using Ecom.Core.Dtos.UserCreationDto;
using Ecom.DAL.Data;
using Ecom.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecom.BLL.Implementation.AccountServices
{
    public class AccountRegisterService : IAccountInterface
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly ITokenInterface _token;
        public AccountRegisterService(UserManager<AppUser> userManager, ITokenInterface token){

            _userManager = userManager;

            _token = token;

        }

        public async Task<UserCreationDto> RegisterAccountAsync(RegisterDto registerDto)
    {
        var appUser = new AppUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email
        };

        var creationResult = await _userManager.CreateAsync(appUser, registerDto.Password);

        if (!creationResult.Succeeded)
        {
            var errors = string.Join("; ", creationResult.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
        }

        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

        if (!roleResult.Succeeded)
        {
            
            var roleErrors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
            throw new Exception($"User role assignment failed: {roleErrors}");
        }

        return new UserCreationDto{
            UserName = appUser.UserName,
            Email= appUser.Email,
            Token = _token.CreateToken(appUser)
        };
    }
        
    }
}