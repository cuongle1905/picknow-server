using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class StoreProductView
    {
        public int StoreGroup { get; set; }
        public int StoreProductGroup { get; set; }
        public decimal? Price { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public string Code { get; set; }
        public int? Brand { get; set; }
        public short? Origin { get; set; }
        public int? Size { get; set; }
        public short? Color { get; set; }
        public string Description { get; set; }
        public int? Image { get; set; }
        public string ImageFile { get; set; }
        public string StoreProductGroups { get; set; }
    }
}
