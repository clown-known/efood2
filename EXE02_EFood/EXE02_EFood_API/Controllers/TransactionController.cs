using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IPremium_hisRepository _premiumHisRepository;
        private readonly IPremiumRepository _premiumRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;


        public TransactionController(ITransactionRepository transactionRepository, IPremium_hisRepository premium_HisRepository, IPremiumRepository premiumRepository, IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _premiumRepository = premiumRepository;
            _premiumHisRepository = premium_HisRepository;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            var transactions = _transactionRepository.GetAll();
            return Ok(transactions);
        }
        [HttpGet("pending")]
        public IActionResult GetPendingTransactions()
        {
            var transactions = _transactionRepository.GetAll().Where(a=>a.Note.EndsWith("pending"));
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaction(int id)
        {
            var transaction = _transactionRepository.Get(id);
            if (transaction == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Transaction not found",
                    Data = null
                });
            }

            return Ok(transaction);
        }

        [HttpPost]
        public IActionResult CreateTransaction(TransApiModel trans)
        {
            Transaction transaction = new Transaction();
            transaction.PaymentMethodId = trans.paymentMethodId;
            transaction.AccountId = trans.accountId;
            transaction.Value = trans.value;
            transaction.TimeTrans = DateTime.Now;
            transaction.IsSuccess = false;
            transaction.Note = "pending";
            _transactionRepository.Create(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(int id, Transaction transaction)
        {
            var existingTransaction = _transactionRepository.Get(id);
            if (existingTransaction == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Transaction not found",
                    Data = transaction
                });
            }

            existingTransaction.PaymentMethodId = transaction.PaymentMethodId;
            existingTransaction.AccountId = transaction.AccountId;
            existingTransaction.Value = transaction.Value;
            existingTransaction.TimeTrans = transaction.TimeTrans;
            existingTransaction.IsSuccess = transaction.IsSuccess;
            existingTransaction.Note = transaction.Note;

            _transactionRepository.Update(existingTransaction);

            return NoContent();
        }
        [HttpPut("confirm/{transid}")]
        public IActionResult ConfirmPremium(int transid)
        {
            // update transaction
            var existingTransaction = _transactionRepository.Get(transid);
            if (existingTransaction == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Transaction not found",

                });
            }
            existingTransaction.IsSuccess = true;
            existingTransaction.Note = "done";
            int accountid = existingTransaction.AccountId.Value;
            int userid = _accountRepository.Get(accountid).UserId.Value;
            _transactionRepository.Update(existingTransaction);
            // end update transaction
            // update premium in user
            var user = _userRepository.Get(userid);
            if (user != null)
            {
                if (user.IsPremium)
                {
                    // update premium
                    PremiumHi existPre = _premiumHisRepository.GetByUserId(userid).Where(p => p.TimeEnd > DateTime.Now).FirstOrDefault();
                    if (existPre != null)
                    {
                        existPre.TimeStart = existPre.TimeStart;
                        foreach (Premium p in _premiumRepository.GetAll())
                        {
                            if (p.Value == existingTransaction.Value)
                            {
                                var time = p.Period;
                                existPre.TimeEnd = existPre.TimeEnd.Value.AddMonths(Int32.Parse(time));
                            }
                        }
                    }
                    existPre.Status = 1;
                    existPre.UserId = userid;
                    _premiumHisRepository.Update(existPre);
                }
                else
                {
                    user.IsPremium = true;
                    _userRepository.Update(user);
                    // update premium
                    PremiumHi newp = new PremiumHi();
                    newp.TimeStart = DateTime.Now;
                    foreach (Premium p in _premiumRepository.GetAll())
                    {
                        if (p.Value == existingTransaction.Value)
                        {
                            newp.PremiumId = p.PremiumId;
                            var time = p.Period;
                            newp.TimeEnd = DateTime.Now.AddMonths(Int32.Parse(time));
                        }
                    }
                    newp.Status = 1;
                    newp.UserId = userid;
                    _premiumHisRepository.Create(newp);
                }
            }
            
            // end update premium

          

            return Ok();
        }
        [HttpPut("denied/{transid}")]
        public IActionResult DeniedPremium(int transid)
        {
            // update transaction
            var existingTransaction = _transactionRepository.Get(transid);
            if (existingTransaction == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Transaction not found",

                });
            }
            existingTransaction.IsSuccess = false;
            existingTransaction.Note = "denied";
            _transactionRepository.Update(existingTransaction);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int id)
        {
            var transaction = _transactionRepository.Get(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _transactionRepository.Delete(id);

            return NoContent();
        }
    }

}
