using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class CompanyLogo
    {
        public int CompanyId { get; set; }
        public int? Logo { get; set; }
        public string FileName { get; set; }
    }
}
