using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class ReviewOfDish
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? DishId { get; set; }
        public TimeSpan? Time { get; set; }
        public string Comment { get; set; }
        public int? Voting { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual User User { get; set; }
    }
}
