using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class ReviewOfRe
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? ResId { get; set; }
        public int? Voting { get; set; }
        public string Comment { get; set; }
        public TimeSpan? Time { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Restaurant Res { get; set; }
        public virtual User User { get; set; }
    }
}
