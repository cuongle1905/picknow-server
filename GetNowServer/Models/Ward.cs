using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Ward
    {
        public Ward()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int District { get; set; }
        public int? Code { get; set; }

        public virtual District DistrictNavigation { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
