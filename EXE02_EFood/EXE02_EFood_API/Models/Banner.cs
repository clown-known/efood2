using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Banner
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int? ResManagerId { get; set; }
        public string Image { get; set; }
        public TimeSpan? CreatedTime { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual RestaurantManager ResManager { get; set; }
    }
}
