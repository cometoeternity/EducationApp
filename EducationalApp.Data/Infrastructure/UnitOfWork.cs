using EducationalApp.Model.Base;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EducationalApp.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : ApplicationDbContext
    {
        private readonly TContext _context;
        private bool _disposed;
        private IDbContextTransaction _objTran;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public TContext Context
        {
            get { return _context; }
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void CreateTransaction()
        {
            _objTran = _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing) _context.Dispose();
            _disposed = true;
        }

        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbException dbEx)
            {
                throw new Exception("Error from Unit Of Work Save Method", dbEx);
            }
        }

        public Repository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<T>);
                var repositoryInstanse = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstanse);
            }
            return (Repository<T>)_repositories[type];
        }
    }
}
