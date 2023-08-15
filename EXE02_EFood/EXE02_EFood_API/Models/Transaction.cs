using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? AccountId { get; set; }
        public int? Value { get; set; }
        public DateTime TimeTrans { get; set; }
        public bool IsSuccess { get; set; }
        public string Note { get; set; }

        public virtual Account Account { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
