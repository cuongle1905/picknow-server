using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class Company
    {
        public Company()
        {
            StoreGroups = new HashSet<StoreGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string TaxCode { get; set; }
        public int? Logo { get; set; }

        public virtual ImageInfo LogoNavigation { get; set; }
        public virtual ICollection<StoreGroup> StoreGroups { get; set; }
    }
}
