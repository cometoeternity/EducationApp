using EducationalApp.Data.Infrastructure;
using EducationalApp.Data.Repository;
using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(Guid id);
        Order CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid id);
        void SaveOrder();
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public Order CreateOrder(Order order)
        {
            _orderRepository.Insert(order);
            SaveOrder();
            return order;
        }

        public void DeleteOrder(Guid id)
        {
            _orderRepository.Delete(id);
            SaveOrder();
        }

        public Order GetOrder(Guid id)
        {
            var order = _orderRepository.GetById(id);
            return order;
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _orderRepository.GetAll().OrderByDescending(d => d.CreatedAt);
            return orders;

        }

        public void SaveOrder()
        {
            _unitOfWork.Commit();
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            SaveOrder();
        }
    }
}
