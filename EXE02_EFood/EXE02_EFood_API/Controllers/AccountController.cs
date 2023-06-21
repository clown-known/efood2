using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountRepository.GetAll();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var account = _accountRepository.Get(id);
            if (account == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Can not get Account",
                    Data = account
                });
            }
            return Ok(account);
        }

        [HttpPost]
        public IActionResult CreateAccount(Account account)
        {
            _accountRepository.Create(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, Account account)
        {
            var existingAccount = _accountRepository.Get(id);
            if (existingAccount == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Can not update Account",
                    Data = account
                });
            }

            existingAccount.Email = account.Email;
            existingAccount.Password = account.Password;
            existingAccount.Role = account.Role;

            _accountRepository.Update(existingAccount);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var account = _accountRepository.Get(id);
            if (account == null)
            {
                return NotFound();
            }

           // _accountRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchAccount(string keyword)
        {
            var accounts = _accountRepository.GetAll().Where(a => a.Email.ToLower().Contains(keyword.ToLower())).ToList();
            if (accounts.Count == 0)
            {
                return NotFound();
            }
            return Ok(accounts);
        }
    }

}
