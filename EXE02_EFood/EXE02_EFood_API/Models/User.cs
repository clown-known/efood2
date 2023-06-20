using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            ReviewOfDishes = new HashSet<ReviewOfDish>();
            ReviewOfRes = new HashSet<ReviewOfRe>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public bool IsPremium { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ReviewOfDish> ReviewOfDishes { get; set; }
        public virtual ICollection<ReviewOfRe> ReviewOfRes { get; set; }
    }
}
