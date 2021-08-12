using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Entities;

namespace EducationalApp.Data.Repository
{
    public class SuppliersRepository : Repository<Supplier>, IRepository<Supplier>
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        { }

    }
}