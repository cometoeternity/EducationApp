using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Service.Interfaces
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
}
