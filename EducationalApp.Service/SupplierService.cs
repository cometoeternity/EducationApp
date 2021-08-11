using EducationalApp.Data.Infrastructure;
using EducationalApp.Service.DTO;
using EducationalApp.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace EducationalApp.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SupplierDTO CreateSupplier(SupplierDTO supplier)
        {
            try
            {
                _unitOfWork.SupplierRepository.Insert(supplier);
                SaveSupplier();
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return supplier;
        }

        public void DeleteSupplier(Guid id)
        {
            _unitOfWork.SupplierRepository.Delete(id);
            SaveSupplier();
        }

        public void EditSupplier(SupplierDTO supplier)
        {
            _unitOfWork.SupplierRepository.Update(supplier);
            SaveSupplier();
        }

        public SupplierDTO GetSupplierByEmail(string email)
        {
            var suppliers = _unitOfWork.SupplierRepository.Get(s => s.ContactEmail.Contains(email));
            return suppliers;
        }

        public SupplierDTO GetSupplierByName(string name)
        {
            var suppliers = _unitOfWork.SupplierRepository.Get(s => s.Name.Contains(name));
            return suppliers;
        }

        public SupplierDTO GetSupplierByNumber(string number)
        {
            var suppliers = _unitOfWork.SupplierRepository.Get(s => s.ContactNumber.Contains(number));
            return suppliers;
        }

        public IEnumerable<SupplierDTO> GetSuppliers()
        {
            var suppliers = _unitOfWork.SupplierRepository.GetAll();
            return suppliers;
        }

        public void SaveSupplier()
        {
            _unitOfWork.Save();
        }
    }
}
