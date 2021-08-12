using EducationalApp.Model.Base;

namespace EducationalApp.Model.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
    }
}
