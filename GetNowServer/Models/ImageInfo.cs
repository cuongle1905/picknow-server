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
        }

        public int Id { get; set; }
        public string FileName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
