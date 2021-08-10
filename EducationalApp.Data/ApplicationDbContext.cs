using EducationalApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        protected ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=EdacationalApp;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}  

