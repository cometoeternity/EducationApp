using EducationalApp.Data.Infrastructure;
using EducationalApp.Model;

namespace EducationalApp.Data.Repository
{
    public class SuppliersRepository : Repository<Supplier>, ISupplierRepository
    {
        public SuppliersRepository(ApplicationDbContext context):base(context)
        { }
        public SuppliersRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
        { }
    }
    public interface ISupplierRepository : IRepository<Supplier>
    { }
}
