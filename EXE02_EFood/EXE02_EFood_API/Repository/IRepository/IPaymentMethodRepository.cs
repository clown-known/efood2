using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IPaymentMethodRepository
    {
        public PaymentMethod Create(PaymentMethod paymentMethod);
        public void Update(PaymentMethod paymentMethod);
        public PaymentMethod Get(int id);
        public List<PaymentMethod> GetAll();
        public void Delete(int id);
    }
}
