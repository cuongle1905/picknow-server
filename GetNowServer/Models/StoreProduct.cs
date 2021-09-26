using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class StoreProduct
    {
        public int StoreProductGroup { get; set; }
        public long Product { get; set; }
        public decimal? Price { get; set; }

        public virtual Product ProductNavigation { get; set; }
        public virtual StoreProductGroup StoreProductGroupNavigation { get; set; }
    }
}
