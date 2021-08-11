using EducationalApp.Model.Models;

namespace EducationalApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }
        void Rollback();
        void Save();
    }
}