using EducationalApp.Common.DTO;
using System;


namespace EducationalApp.Model.Interfaces
{
    public interface ISupplierService : IService<SupplierDTO>
    {
        void EditSupplier(SupplierDTO supplier);
        SupplierDTO GetSupplierByName(string name);
        SupplierDTO GetSupplierByNumber(string number);
        SupplierDTO GetSupplierByEmail(string email);

    }
}
