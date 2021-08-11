using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;

namespace EducationalApp.Data.Repository
{
    public class OrderRepository : Repository<Order>, IRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
