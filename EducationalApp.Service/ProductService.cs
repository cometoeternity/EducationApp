using EducationalApp.Data.Infrastructure;
using EducationalApp.Service.DTO;
using EducationalApp.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace EducationalApp.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductDTO CreateProduct(ProductDTO product)
        {
            try
            {
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

        public ProductDTO GetProductByCategory(string category)
        {
            var products = _unitOfWork.ProductRepository.Get(p => p.Category.Contains(category));
            return products;
        }

        public ProductDTO GetProductByName(string name)
        {
            var products = _unitOfWork.ProductRepository.Get(p => p.Name.Contains(name));
            return products;
        }


        public IEnumerable<ProductDTO> GetProducts()
        {
            var product = _unitOfWork.ProductRepository.GetAll();
            return product;
        }

        public void SaveProduct()
        {
            _unitOfWork.Save();
        }

        public void UpdateProduct(ProductDTO product)
        {
            _unitOfWork.ProductRepository.Update(product);
            SaveProduct();
        }
    }
}
