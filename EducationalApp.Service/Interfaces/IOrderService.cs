using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;

namespace EducationalApp.Service.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(Guid id);
        Order CreateOrder(Order orderDTO);
        void UpdateOrder(Order orderDTO);
        void DeleteOrder(Guid id);
        void SaveOrder();
    }
}
