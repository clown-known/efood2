using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Dish
    {
        public Dish()
        {
            ReviewOfDishes = new HashSet<ReviewOfDish>();
        }

        public int DishId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? VoteRating { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ReviewOfDish> ReviewOfDishes { get; set; }
    }
}
