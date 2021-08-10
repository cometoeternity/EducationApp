using EducationalApp.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace EducationalApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}