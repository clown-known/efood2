using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Notify
    {
        public int NotifyId { get; set; }
        public int? ResId { get; set; }
        public string Detail { get; set; }
        public int? ToUserId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Restaurant Res { get; set; }
    }
}
