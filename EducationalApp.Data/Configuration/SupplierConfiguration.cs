using EducationalApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalApp.Data.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Property(p => p.ContactNumber).IsRequired().HasMaxLength(20);
            builder.Property(p => p.ContactEmail).IsRequired().HasMaxLength(35);
            builder.Property(p => p.ContactPerson).IsRequired().HasMaxLength(50);
        }
    }
}
