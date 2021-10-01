using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Product
    {
        public Product()
        {
            StoreProducts = new HashSet<StoreProduct>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public string Code { get; set; }
        public int? Brand { get; set; }
        public short? Origin { get; set; }
        public int? Size { get; set; }
        public short? Color { get; set; }
        public string Description { get; set; }
        public int? Image { get; set; }

        public virtual Brand BrandNavigation { get; set; }
        public virtual Color ColorNavigation { get; set; }
        public virtual ImageInfo ImageNavigation { get; set; }
        public virtual Origin OriginNavigation { get; set; }
        public virtual Size SizeNavigation { get; set; }
        public virtual Unit UnitNavigation { get; set; }
        public virtual ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
