using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Model.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace EducationalApp.Model.Base
    {
        public class BaseEntity
        {
            public Guid Id { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }
}
