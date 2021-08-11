using EducationalApp.Data.Repository;
using EducationalApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }

        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}