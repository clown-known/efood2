using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class DishCategory
    {
        public int CategoryId { get; set; }
        public int DishId { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
