using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class ImageInfo
    {
        public ImageInfo()
        {
            Companies = new HashSet<Company>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
