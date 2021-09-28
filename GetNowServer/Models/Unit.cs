using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public sbyte? BaseUnit { get; set; }
        public double? Exchange { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
