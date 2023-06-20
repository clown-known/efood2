using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class AccountPayment
    {
        public int UserPaymentId { get; set; }
        public int? AccountId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Account Account { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
