using System;
using System.Collections.Generic;
using EducationalApp.Common.DTO.BaseDTO;

namespace EducationalApp.Model.Interfaces
{
    public interface IService<T> where T : DTOBase
    {
        IEnumerable<T> GetAll();
        T Create(T dto);
        T GetById(Guid id);
        void Update(T dto);
        void Delete(Guid id);
    }
}
