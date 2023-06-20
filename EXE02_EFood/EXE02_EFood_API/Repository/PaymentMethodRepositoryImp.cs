using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class PaymentMethodRepositoryImp : IPaymentMethodRepository
    {
        private readonly E_FoodContext _context;

        public PaymentMethodRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public PaymentMethod Create(PaymentMethod paymentMethod)
        {
            var newPaymentMethod = new PaymentMethod
            {
                Name = paymentMethod.Name,
                Description = paymentMethod.Description,
                Token = paymentMethod.Token,
                Status = paymentMethod.Status,
                IsDeleted = paymentMethod.IsDeleted
            };

            _context.PaymentMethods.Add(newPaymentMethod);
            _context.SaveChanges();

            return newPaymentMethod;
        }

        public PaymentMethod Get(int id)
        {
            var paymentMethod = _context.PaymentMethods.SingleOrDefault(p => p.PaymentMethodId == id);
            return paymentMethod;
        }

        public List<PaymentMethod> GetAll()
        {
            var paymentMethods = _context.PaymentMethods.Where(p => !p.IsDeleted).ToList();
            return paymentMethods;
        }

        public void Update(PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = _context.PaymentMethods.SingleOrDefault(p => p.PaymentMethodId == paymentMethod.PaymentMethodId);

            if (existingPaymentMethod != null)
            {
                existingPaymentMethod.Name = paymentMethod.Name;
                existingPaymentMethod.Description = paymentMethod.Description;
                existingPaymentMethod.Token = paymentMethod.Token;
                existingPaymentMethod.Status = paymentMethod.Status;
                existingPaymentMethod.IsDeleted = paymentMethod.IsDeleted;

                _context.PaymentMethods.Update(existingPaymentMethod);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var paymentMethod = _context.PaymentMethods.SingleOrDefault(p => p.PaymentMethodId == id);

            if (paymentMethod != null)
            {
                _context.PaymentMethods.Remove(paymentMethod);
                _context.SaveChanges();
            }
        }
    }
}
