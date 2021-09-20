using System;
using System.Collections.Generic;

#nullable disable

namespace PickNowWeb.Models
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public short Country { get; set; }

        public virtual Country CountryNavigation { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
