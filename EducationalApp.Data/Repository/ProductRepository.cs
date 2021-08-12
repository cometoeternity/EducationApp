using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Entities;
using EducationalApp.Model.Interfaces;

namespace EducationalApp.Data.Repository
{
    public class ProductRepository : Repository<Product>, IRepository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
