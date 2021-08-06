using EducationalApp.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Infrastructure.Contexts
{
    public class SqlProductRepository : IProductRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product[] GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
