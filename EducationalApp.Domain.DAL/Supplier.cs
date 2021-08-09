using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Model
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
    }
}
