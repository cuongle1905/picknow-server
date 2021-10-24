using System;
using System.Collections.Generic;

#nullable disable

namespace GetNowServer.Models
{
    public partial class ProductSearch
    {
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
        public string SearchName { get; set; }
    }
}
