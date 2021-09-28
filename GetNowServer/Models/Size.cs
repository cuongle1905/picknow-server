using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Size
    {
        public Size()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Weight { get; set; }
        public double? Volumn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
