using EducationalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Data.Infrastructure
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        void Save(Product product);
        void Delete(Guid id);
        Product[] GetAll();
    }
}
