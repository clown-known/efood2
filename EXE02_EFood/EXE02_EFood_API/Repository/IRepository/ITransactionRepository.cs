using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface ITransactionRepository
    {
        public Transaction Create(Transaction transaction);
        public Transaction Get(int id);
        public List<Transaction> GetAll();
        public void Update(Transaction transaction);
        public void Delete(int id);

    }
}
