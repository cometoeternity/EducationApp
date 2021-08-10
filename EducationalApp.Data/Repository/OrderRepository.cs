using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;

namespace EducationalApp.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        { }
    }
    public interface IOrderRepository : IRepository<Order>
    { }
}
