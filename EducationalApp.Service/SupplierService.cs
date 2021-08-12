using EducationalApp.Common.DTO;
using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Interfaces;
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

        public SupplierDTO Create(SupplierDTO dto)
        {
            try
            {
                _unitOfWork.SupplierRepository.Insert(dto);
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return dto;
        }


        public void Delete(Guid id)
        {
            _unitOfWork.SupplierRepository.Delete(id);
        }

        public void EditSupplier(SupplierDTO supplier)
        {
            _unitOfWork.SupplierRepository.Update(supplier);
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            var suppliers = _unitOfWork.SupplierRepository.GetAll();
            return suppliers;
        }

        public SupplierDTO GetById(Guid id)
        {
            var supplier = _unitOfWork.SupplierRepository.GetById(id);
            return supplier;
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


        public void Update(SupplierDTO dto)
        {
            _unitOfWork.SupplierRepository.Update(dto);
        }
    }
}
