using EducationalApp.Data.Infrastructure;
using EducationalApp.Model;

namespace EducationalApp.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context):base(context)
        {}
        public OrderRepository(IUnitOfWork<ApplicationDbContext> unitOfWork):base(unitOfWork)
        {}
    }
    public interface IOrderRepository : IRepository<Order>
    { }
}
