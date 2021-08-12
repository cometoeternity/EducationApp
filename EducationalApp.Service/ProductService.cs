using EducationalApp.Common.DTO;
using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Interfaces;
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

        public ProductDTO Create(ProductDTO dto)
        {
            try
            {
                _unitOfWork.ProductRepository.Insert(dto);
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return dto;
        }



        public void Delete(Guid id)
        {
            _unitOfWork.ProductRepository.Delete(id);
        }

        public void EditProduct(Guid id, string name, string description, string category, decimal price)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            product.Name = name;
            product.Description = description;
            product.Category = category;
            product.UnitPrice = price;
            Update(product);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var product = _unitOfWork.ProductRepository.GetAll();
            return product;
        }

        public ProductDTO GetById(Guid id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            return product;
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
    

        public void Update(ProductDTO dto)
        {
            _unitOfWork.ProductRepository.Update(dto);
        }
    }  
}

