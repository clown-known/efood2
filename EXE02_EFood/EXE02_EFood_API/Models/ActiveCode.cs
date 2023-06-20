using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class ActiveCode
    {
        public int ActiveId { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
