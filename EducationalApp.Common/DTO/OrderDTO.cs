using EducationalApp.Common.DTO.BaseDTO;
using System.Collections.Generic;

namespace EducationalApp.Common.DTO
{
    public class OrderDTO : DTOBase
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public int Zip { get; set; }
        public string Country { get; set; }
        public List<ProductDTO> ProductsDTO { get; set; }
    }
}
