using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;

namespace EducationalApp.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        { }
        public ProductRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
        { }
    }
    public interface IProductRepository : IRepository<Product>
    { }
}
