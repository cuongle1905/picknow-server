using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Color
    {
        public Color()
        {
            Products = new HashSet<Product>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
