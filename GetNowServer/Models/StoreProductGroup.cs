using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class StoreProductGroup
    {
        public StoreProductGroup()
        {
            StoreProducts = new HashSet<StoreProduct>();
        }

        public int Id { get; set; }
        public int StoreGroup { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }

        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
