using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Entities;

namespace EducationalApp.Data.Repository
{
    public class OrderRepository : Repository<Order>, IRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
