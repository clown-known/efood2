using System;
using System.Collections.Generic;

#nullable disable

namespace EXE02_EFood_API.Models
{
    public partial class Premium
    {
        public int PremiumId { get; set; }
        public int? Value { get; set; }
        public string Period { get; set; }
    }
}
