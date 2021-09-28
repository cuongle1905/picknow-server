using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class StoreGroup
    {
        public StoreGroup()
        {
            Stores = new HashSet<Store>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Company { get; set; }

        public virtual Company CompanyNavigation { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
