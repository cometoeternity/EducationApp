using EducationalApp.Common.DTO;
using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationalApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OrderDTO Create(OrderDTO dto)
        {
            try
            {
                _unitOfWork.OrderRepository.Insert(dto);
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return dto;
        }

        
        public void Delete(Guid id)
        {
            _unitOfWork.OrderRepository.Delete(id);
        }


        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _unitOfWork.OrderRepository.GetAll().OrderByDescending(d => d.CreatedAt);
            return orders;
        }

        public OrderDTO GetById(Guid id)
        {
            var order = _unitOfWork.OrderRepository.GetById(id);
            return order;
        }


        public void Update(OrderDTO dto)
        {
            _unitOfWork.OrderRepository.Update(dto);
        }

    }
}
