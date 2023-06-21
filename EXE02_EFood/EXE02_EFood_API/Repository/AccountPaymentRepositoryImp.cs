using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class AccountPaymentRepositoryImp : IAccountPaymentRepository
    {
        private readonly E_FoodContext _context;

        public AccountPaymentRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public AccountPayment Create(AccountPayment accountPayment)
        {
            var newAccountPayment = new AccountPayment
            {
                AccountId = accountPayment.AccountId,
                PaymentMethodId = accountPayment.PaymentMethodId,
                Status = accountPayment.Status,
                IsDeleted = accountPayment.IsDeleted
            };

            _context.AccountPayments.Add(newAccountPayment);
            _context.SaveChanges();

            return newAccountPayment;
        }

        public AccountPayment Get(int id)
        {
            var accountPayment = _context.AccountPayments.SingleOrDefault(ap => ap.UserPaymentId == id);
            return accountPayment;
        }

        public List<AccountPayment> GetAll()
        {
            var accountPayments = _context.AccountPayments.ToList();
            return accountPayments;
        }

        public void Update(AccountPayment accountPayment)
        {
            var existingAccountPayment = _context.AccountPayments.SingleOrDefault(ap => ap.UserPaymentId == accountPayment.UserPaymentId);
            if (existingAccountPayment != null)
            {
                existingAccountPayment.AccountId = accountPayment.AccountId;
                existingAccountPayment.PaymentMethodId = accountPayment.PaymentMethodId;
                existingAccountPayment.Status = accountPayment.Status;
                existingAccountPayment.IsDeleted = accountPayment.IsDeleted;

                _context.AccountPayments.Update(existingAccountPayment);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var accountPayment = _context.AccountPayments.SingleOrDefault(ap => ap.UserPaymentId == id);
            if (accountPayment != null)
            {
                _context.AccountPayments.Remove(accountPayment);
                _context.SaveChanges();
            }
        }
    }

}
