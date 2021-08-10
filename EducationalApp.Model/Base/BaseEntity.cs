using System;

namespace EducationalApp.Model.Base
    {
        public class BaseEntity
        {
            public Guid Id { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }

