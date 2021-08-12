using EducationalApp.Common.DTO.BaseDTO;


namespace EducationalApp.Common.DTO
{
    public class SupplierDTO : DTOBase
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
    }
}
