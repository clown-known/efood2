using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class TransactionRepositoryImp : ITransactionRepository
    {
        private readonly E_FoodContext _context;

        public TransactionRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Transaction Create(Transaction transaction)
        {
            var newTransaction = new Transaction
            {
                PaymentMethodId = transaction.PaymentMethodId,
                AccountId = transaction.AccountId,
                Value = transaction.Value,
                TimeTrans = transaction.TimeTrans,
                IsSuccess = transaction.IsSuccess,
                Note = transaction.Note
            };

            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();

            return newTransaction;
        }

        public Transaction Get(int id)
        {
            var transaction = _context.Transactions.SingleOrDefault(t => t.TransactionId == id);
            return transaction;
        }

        public List<Transaction> GetAll()
        {
            var transactions = _context.Transactions.ToList();
            return transactions;
        }

        public void Update(Transaction transaction)
        {
            var existingTransaction = _context.Transactions.SingleOrDefault(t => t.TransactionId == transaction.TransactionId);
            if (existingTransaction != null)
            {
                existingTransaction.PaymentMethodId = transaction.PaymentMethodId;
                existingTransaction.AccountId = transaction.AccountId;
                existingTransaction.Value = transaction.Value;
                existingTransaction.TimeTrans = transaction.TimeTrans;
                existingTransaction.IsSuccess = transaction.IsSuccess;
                existingTransaction.Note = transaction.Note;

                _context.Transactions.Update(existingTransaction);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var transaction = _context.Transactions.SingleOrDefault(t => t.TransactionId == id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }

}
