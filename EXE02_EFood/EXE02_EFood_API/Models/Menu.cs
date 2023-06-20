using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Menu
    {
        public int ResId { get; set; }
        public int DishId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Restaurant Res { get; set; }
    }
}
