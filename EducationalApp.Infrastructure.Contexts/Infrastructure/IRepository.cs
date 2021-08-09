using EducationalApp.Model.Base;
using System;
using System.Linq;

namespace EducationalApp.Data.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
