using EducationalApp.Common.DTO.BaseDTO;
using System;

namespace EducationalApp.Common.DTO
{
    public class ProductDTO : DTOBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
