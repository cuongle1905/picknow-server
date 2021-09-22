using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Country
    {
        public Country()
        {
            Provinces = new HashSet<Province>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
    }
}
