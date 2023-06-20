using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            AccountPayments = new HashSet<AccountPayment>();
            Transactions = new HashSet<Transaction>();
        }

        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<AccountPayment> AccountPayments { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
