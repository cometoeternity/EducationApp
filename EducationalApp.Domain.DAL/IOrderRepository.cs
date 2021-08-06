using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Domain.DAL
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        void Save(Order order);
    }
}
