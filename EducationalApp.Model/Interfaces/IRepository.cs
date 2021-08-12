using EducationalApp.Model.Base;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EducationalApp.Model.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        T Get(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void Delete(Expression<Func<T, bool>> where);
    }
}
