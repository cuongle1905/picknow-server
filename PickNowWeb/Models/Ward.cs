using System;
using System.Collections.Generic;

#nullable disable

namespace PickNowWeb.Models
{
    public partial class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int District { get; set; }
        public int? Code { get; set; }

        public virtual District DistrictNavigation { get; set; }
    }
}
