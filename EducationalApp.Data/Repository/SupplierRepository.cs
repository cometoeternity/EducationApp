using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;

namespace EducationalApp.Data.Repository
{
    public class SuppliersRepository : Repository<Supplier>, IRepository<Supplier>
    {
        public SuppliersRepository(ApplicationDbContext context) : base(context)
        { }

    }
}