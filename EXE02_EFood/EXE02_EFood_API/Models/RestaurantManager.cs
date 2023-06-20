using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class RestaurantManager
    {
        public RestaurantManager()
        {
            Accounts = new HashSet<Account>();
            Banners = new HashSet<Banner>();
        }

        public int ResManagerId { get; set; }
        public int? ResId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? SendNotifyCount { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Restaurant Res { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Banner> Banners { get; set; }
    }
}
