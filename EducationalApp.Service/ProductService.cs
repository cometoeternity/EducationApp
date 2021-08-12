using AutoMapper;
using EducationalApp.Common.DTO;
using EducationalApp.Model.Entities;
using EducationalApp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationalApp.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ProductDTO Create(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            try
            {
                _unitOfWork.ProductRepository.Insert(product);
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
            var productDTO = _mapper.Map<ProductDTO>(product);
            productDTO.Name = name;
            productDTO.Description = description;
            productDTO.Category = category;
            productDTO.UnitPrice = price;
            Update(productDTO);
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _unitOfWork.ProductRepository.GetAll().AsEnumerable();
            var productDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productDTO;
        }

        public ProductDTO GetById(Guid id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public ProductDTO GetProductByCategory(string category)
        {
            var product = _unitOfWork.ProductRepository.Get(p => p.Category.Contains(category));
            var productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public ProductDTO GetProductByName(string name)
        {
            var product = _unitOfWork.ProductRepository.Get(p => p.Name.Contains(name));
            var productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }
    

        public void Update(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            _unitOfWork.ProductRepository.Update(product);
        }
    }  
}

