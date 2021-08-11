using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;

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
