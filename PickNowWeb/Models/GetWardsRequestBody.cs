﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNowWeb.Models
{
    public class GetWardsRequestBody
    {
        public int district_id { get; set; }
        public int province_id { get; set; }
    }
}