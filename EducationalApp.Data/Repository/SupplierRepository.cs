using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;

namespace EducationalApp.Data.Repository
{
    public class SuppliersRepository : Repository<Supplier>, ISupplierRepository
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        { }

    }
    public interface ISupplierRepository : IRepository<Supplier>
    { }
}