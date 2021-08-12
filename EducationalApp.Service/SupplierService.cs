using EducationalApp.Common.DTO;
using EducationalApp.Model.Interfaces;
using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using EducationalApp.Model.Entities;

namespace EducationalApp.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public SupplierDTO Create(SupplierDTO dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);
            try
            {
                _unitOfWork.SupplierRepository.Insert(supplier);
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

        public void EditSupplier(SupplierDTO supplierDTO)
        {
            var supplier = _mapper.Map<Supplier>(supplierDTO);
            _unitOfWork.SupplierRepository.Update(supplier);
        }

        public IEnumerable<SupplierDTO> GetAll()
        {
            var suppliers = _unitOfWork.SupplierRepository.GetAll().AsEnumerable();
            var suppliersDTO = _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);
            return suppliersDTO;
        }

        public SupplierDTO GetById(Guid id)
        {
            var supplier = _unitOfWork.SupplierRepository.GetById(id);
            var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
            return supplierDTO;
        }

        public SupplierDTO GetSupplierByEmail(string email)
        {
            var supplier = _unitOfWork.SupplierRepository.Get(s => s.ContactEmail.Contains(email));
            var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
            return supplierDTO;
        }

        public SupplierDTO GetSupplierByName(string name)
        {
            var supplier = _unitOfWork.SupplierRepository.Get(s => s.Name.Contains(name));
            var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
            return supplierDTO;
        }

        public SupplierDTO GetSupplierByNumber(string number)
        {
            var supplier = _unitOfWork.SupplierRepository.Get(s => s.ContactNumber.Contains(number));
            var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
            return supplierDTO;
        }


        public void Update(SupplierDTO dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);
            _unitOfWork.SupplierRepository.Update(supplier);
        }
    }
}
