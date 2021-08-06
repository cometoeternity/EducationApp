using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Domain.DAL
{
    public interface ISupplierRepository
    {
        Supplier GetById(Guid id);
        void Save(Supplier supplier);
        void Delete(Guid id);
        Supplier[] GetAll();
    }
}
