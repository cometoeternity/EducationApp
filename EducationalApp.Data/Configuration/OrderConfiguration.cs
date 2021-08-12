using EducationalApp.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalApp.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Zip).IsRequired().HasMaxLength(12);
            builder.Property(p => p.State).IsRequired().HasMaxLength(45);
            builder.Property(p => p.StreetName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.City).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Country).IsRequired().HasMaxLength(25);
            builder.Property(p => p.HouseNumber).IsRequired().HasMaxLength(5);
            builder.Property(p => p.FlatNumber).IsRequired().HasMaxLength(5);
            builder.HasMany(p => p.Products).WithOne();
        }
    }
}
