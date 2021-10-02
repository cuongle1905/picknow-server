using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class StoreProductGroupView
    {
        public int Id { get; set; }
        public int StoreGroup { get; set; }
        public string Name { get; set; }
        public int? Parent { get; set; }
        public int? ProductCount { get; set; }
    }
}
