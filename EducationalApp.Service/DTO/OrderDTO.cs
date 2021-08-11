using System;
using System.Collections.Generic;

namespace EducationalApp.Service.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public List<ProductDTO> ProductsDTO { get; set; }
    }
}
