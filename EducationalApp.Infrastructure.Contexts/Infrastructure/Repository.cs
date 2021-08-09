using EducationalApp.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EducationalApp.Data.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Delete(Guid id)
        {
            T entity = _entities.SingleOrDefault(e => e.Id == id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll() => _entities.AsQueryable();


        public T GetById(Guid id) => _entities.Find(id);
       

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SaveChanges();
        }
    }
}
