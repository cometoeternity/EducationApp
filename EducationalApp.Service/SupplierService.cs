using EducationalApp.Data.Infrastructure;
using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalApp.Service
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

    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Supplier CreateSupplier(Supplier supplier)
        {
            try
            {
                _unitOfWork.CreateTransaction();
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

        public void EditSupplier(Supplier supplier)
        {
            _unitOfWork.SupplierRepository.Update(supplier);
            SaveSupplier();
        }

        public Supplier GetSupplierByEmail(string email)
        {
            var suppliers = _unitOfWork.SupplierRepository.Get(s => s.ContactEmail.Contains(email));
            return suppliers;
        }

        public Supplier GetSupplierByName(string name)
        {
            var suppliers = _unitOfWork.SupplierRepository.Get(s => s.Name.Contains(name));
            return suppliers;
        }

        public Supplier GetSupplierByNumber(string number)
        {
            var suppliers = _unitOfWork.SupplierRepository.Get(s => s.ContactNumber.Contains(number));
            return suppliers;
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            var suppliers = _unitOfWork.SupplierRepository.GetAll();
            return suppliers;
        }

        public void SaveSupplier()
        {
            _unitOfWork.Save();
            _unitOfWork.Commit();
        }
    }
}
