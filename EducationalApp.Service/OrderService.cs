using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;
using EducationalApp.Service.Interfaces;
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

        public Order CreateOrder(Order order)
        {
            try
            {
                _unitOfWork.OrderRepository.Insert(order);
                SaveOrder();
            }
            catch(Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return order;
        }

        public void DeleteOrder(Guid id)
        {
            _unitOfWork.OrderRepository.Delete(id);
            SaveOrder();
        }

        public Order GetOrder(Guid id)
        {
            var order = _unitOfWork.OrderRepository.GetById(id);
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _unitOfWork.OrderRepository.GetAll().OrderByDescending(d => d.CreatedAt);
            return orders;

        }

        public void SaveOrder()
        {
            _unitOfWork.Save();
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
            SaveOrder();
        }
    }
}
