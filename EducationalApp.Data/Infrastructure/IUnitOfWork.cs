using Microsoft.EntityFrameworkCore;

namespace EducationalApp.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}