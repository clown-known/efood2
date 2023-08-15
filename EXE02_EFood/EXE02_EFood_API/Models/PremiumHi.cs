using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class PremiumHi
    {
        public int PremiumId { get; set; }
        public int? UserId { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public int? Status { get; set; }

        public virtual Premium Premium { get; set; }
        public virtual User User { get; set; }
    }
}
