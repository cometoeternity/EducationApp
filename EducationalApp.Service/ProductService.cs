using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;

namespace EducationalApp.Service
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        Product GetProductByName(string name);
        Product GetProductByCategory(string category);
        void UpdateProduct(Product product);
        void EditProduct(Guid id, string name, string description, string category, decimal price);
        IEnumerable<Product> GetProducts();
        void DeleteProduct(Guid id);
        void SaveProduct();
    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Product CreateProduct(Product product)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                _unitOfWork.ProductRepository.Insert(product);
                SaveProduct();
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return product;
        }

        public void DeleteProduct(Guid id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            SaveProduct();
        }

        public void EditProduct(Guid id, string name, string description, string category, decimal price)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            product.Name = name;
            product.Description = description;
            product.Category = category;
            product.UnitPrice = price;
            UpdateProduct(product);
        }

        public Product GetProductByCategory(string category)
        {
            var products = _unitOfWork.ProductRepository.Get(p => p.Category.Contains(category));
            return products;
        }

        public Product GetProductByName(string name)
        {
            var products = _unitOfWork.ProductRepository.Get(p => p.Name.Contains(name));
            return products;
        }


        public IEnumerable<Product> GetProducts()
        {
            var product = _unitOfWork.ProductRepository.GetAll();
            return product;
        }

        public void SaveProduct()
        {
            _unitOfWork.Save();
            _unitOfWork.Commit();
        }

        public void UpdateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            SaveProduct();
        }
    }
}
