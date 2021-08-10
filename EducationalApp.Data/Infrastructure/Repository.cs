using EducationalApp.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EducationalApp.Data.Infrastructure
{
    public class Repository<T> : IDisposable, IRepository<T> where T : BaseEntity
    {

        private DbSet<T> _entities;
        private bool _disposed = false;

        public ApplicationDbContext Context { get; set; }

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }
        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }
        public Repository(IUnitOfWork<ApplicationDbContext> unitOfWork) : this(unitOfWork.Context)
        { }
        public void Delete(Guid id)
        {
            T entity = _entities.SingleOrDefault(e => e.Id == id);
            _entities.Remove(entity);
            Context.SaveChanges();
        }

        public IQueryable<T> GetAll() => _entities.AsQueryable();


        public T GetById(Guid id) => _entities.Find(id);


        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
