using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class SendNotify
    {
        public int SendNotifyId { get; set; }
        public int? Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
