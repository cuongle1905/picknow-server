using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
