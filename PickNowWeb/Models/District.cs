using System;
using System.Collections.Generic;

#nullable disable

namespace PickNowWeb.Models
{
    public partial class District
    {
        public District()
        {
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public short Province { get; set; }
        public short? Code { get; set; }

        public virtual Province ProvinceNavigation { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
