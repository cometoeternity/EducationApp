using EducationalApp.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Infrastructure.Contexts
{
    public class SqlOrderRepository : IOrderRepository
    {
        public Order GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
