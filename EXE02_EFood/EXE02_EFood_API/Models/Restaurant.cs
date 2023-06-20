using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Notifies = new HashSet<Notify>();
            RestaurantManagers = new HashSet<RestaurantManager>();
            ReviewOfRes = new HashSet<ReviewOfRe>();
        }

        public int ResId { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public int? VoteRating { get; set; }
        public string Description { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Log { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Notify> Notifies { get; set; }
        public virtual ICollection<RestaurantManager> RestaurantManagers { get; set; }
        public virtual ICollection<ReviewOfRe> ReviewOfRes { get; set; }
    }
}
