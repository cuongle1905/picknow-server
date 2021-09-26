using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Origin
    {
        public Origin()
        {
            Products = new HashSet<Product>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
