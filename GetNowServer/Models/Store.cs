using System;
using System.Collections.Generic;

#nullable disable

namespace PickNowWeb.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Province { get; set; }
        public int District { get; set; }
        public int Ward { get; set; }
        public string Address { get; set; }
        public int? Company { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactPhone2 { get; set; }
        public string Website { get; set; }

        public virtual Company CompanyNavigation { get; set; }
        public virtual District DistrictNavigation { get; set; }
        public virtual Province ProvinceNavigation { get; set; }
        public virtual Ward WardNavigation { get; set; }
    }
}
