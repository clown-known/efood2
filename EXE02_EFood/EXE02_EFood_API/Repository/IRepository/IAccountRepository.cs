using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IAccountRepository
    {
        public Account Get(int id);
        public Account GetByEmail(string email);
        public List<Account> GetAll();
        public void Update(Account account);
        public Account Create(Account account);
    }
}
