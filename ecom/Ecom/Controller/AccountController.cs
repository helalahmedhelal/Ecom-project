using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Core.Dtos.AccountDtos;
using Ecom.BLL.Interfaces.AccountInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controller
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountInterface _account;

        private readonly IAccountUpdateInterface _accountUpdate;

        private readonly IAccountDeleteInterface _accountDelete;

        public AccountController(IAccountInterface account, IAccountUpdateInterface accountUpdate,
        IAccountDeleteInterface accountDelete){

            _account = account;

            _accountUpdate = accountUpdate;

            _accountDelete = accountDelete;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto){

            if (registerDto == null){

                return BadRequest("Enter valid data");
            }

            var registeredUser = await _account.RegisterAccountAsync(registerDto);

            if (registeredUser == null){

                    return BadRequest("User registration failed.");
                }

            return Ok(registeredUser);    

        }

        [HttpPut("{id}/update")]
        public async Task <IActionResult> Update(string id,[FromBody] UpdateAccountDto updateAccountDto){
            if (updateAccountDto == null){
                return BadRequest("Invalid data");
            }
            var AccountUpdate = await _accountUpdate.UpdateAccountAsync(id, updateAccountDto);

            if (AccountUpdate == null){
                return NotFound();
            }

            return Ok(AccountUpdate);

        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> delete(string id){
            if (id == null){
                return BadRequest($"Invalid id : {id}");
            }
            var AccountDelete = await _accountDelete.DeleteAccountAsync(id);

            if (AccountDelete == false){
                return NotFound($"No such accout with this id : {id}");
            }
            
            return NoContent();
        }
    }
}