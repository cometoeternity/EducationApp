﻿using EducationalApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Model
{
    public class Order : BaseEntity
    {
        
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
