using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class AccountRepositoryImp : IAccountRepository
    {
        private readonly E_FoodContext _context;
        public AccountRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Account Create(Account account)
        {
            var acc = new Account
            {
                Password = account.Password,
                Email = account.Email,
                Role = "user",
                UserId = account.UserId,
                ResManagerId = account.ResManagerId,
                Status = 1
            };
            _context.Accounts.Add(acc);
            _context.SaveChanges();
            return acc;
        }

        public Account Get(int id)
        {
            var result = _context.Accounts.SingleOrDefault(a=>a.AccountId == id);
            return result;
        }
        public Account GetByEmail(string email)
        {
            var result = _context.Accounts.SingleOrDefault(a=>a.Email.Equals(email));
            return result;
        }

        public void Update(Account account)
        {
            var acc = _context.Accounts.SingleOrDefault(a=>a.AccountId == account.AccountId);
            acc.Password = account.Password;
            acc.Email = account.Email;
            acc.Role = account.Role;
            acc.UserId = account.UserId;
            acc.ResManagerId = account.ResManagerId;
            acc.Status = account.Status;
            _context.Accounts.Update(acc);
            _context.SaveChanges();
        }

        List<Account> IAccountRepository.GetAll()
        {
            var result = _context.Accounts.ToList();
            return result;
        }
    }
}
