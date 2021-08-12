using EducationalApp.Model.Base;
using EducationalApp.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EducationalApp.Data.Infrastructure
{
    public class Repository<T> : IDisposable, IRepository<T> where T : BaseEntity
    {
        private DbSet<T> _entities;
        private bool _disposed = false;
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }
        public void Delete(Guid id)
        {
            T entity = _entities.SingleOrDefault(e => e.Id == id);
            _entities.Remove(entity);
        }

        public IQueryable<T> GetAll() => _entities.AsQueryable();


        public T GetById(Guid id) => _entities.Find(id);


        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _entities.Where<T>(where).FirstOrDefault<T>();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IQueryable<T> objects = _entities.Where<T>(where).AsQueryable();
            foreach (T obj in objects)
                _entities.Remove(obj);
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _entities.Where<T>(where).AsQueryable();
        }
    }
}
