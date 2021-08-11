using EducationalApp.Data.Repository;
using EducationalApp.Model.Base;
using EducationalApp.Model.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EducationalApp.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositories;
        private IRepository<Product> _productRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<Supplier> _supplierRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context);
            }
        }
        public IRepository<Order> OrderRepository
        {
            get
            {
                return _orderRepository = _orderRepository ?? new OrderRepository(_context);
            }
        }

        public IRepository<Supplier> SupplierRepository
        {
            get
            {
                return _supplierRepository = _supplierRepository ?? new SuppliersRepository(_context);
            }
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
            _context.Dispose();
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
