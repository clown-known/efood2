using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountPayments = new HashSet<AccountPayment>();
            Transactions = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Status { get; set; }
        public string Role { get; set; }
        public int? UserId { get; set; }
        public int? ResManagerId { get; set; }
        public DateTime? createDate { get; set; }

        public virtual RestaurantManager ResManager { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AccountPayment> AccountPayments { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
