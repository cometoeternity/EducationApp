using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Service.Interfaces
{
    public interface ISupplierService
    {
        Supplier CreateSupplier(Supplier supplier);
        void EditSupplier(Supplier supplier);
        void DeleteSupplier(Guid id);
        void SaveSupplier();
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplierByName(string name);
        Supplier GetSupplierByNumber(string number);
        Supplier GetSupplierByEmail(string email);

    }
}
