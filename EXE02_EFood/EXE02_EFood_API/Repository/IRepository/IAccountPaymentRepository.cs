using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IAccountPaymentRepository
    {
        public void Delete(int id);
        public void Update(AccountPayment accountPayment);
        public List<AccountPayment> GetAll();
        public AccountPayment Get(int id);
        public AccountPayment Create(AccountPayment accountPayment);
    }
}
