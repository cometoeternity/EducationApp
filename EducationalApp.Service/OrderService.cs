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
 
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                _unitOfWork.CreateTransaction();
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
            _unitOfWork.Commit();
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
            SaveOrder();
        }
    }
}
