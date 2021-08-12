using EducationalApp.Model.Entities;
using EducationalApp.Model.Interfaces;

namespace EducationalApp.Model.Interfaces
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