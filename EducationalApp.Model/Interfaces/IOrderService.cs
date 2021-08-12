using EducationalApp.Common.DTO;
using System.Collections.Generic;

namespace EducationalApp.Model.Interfaces
{
    public interface IOrderService : IService<OrderDTO>
    {
        IEnumerable<OrderDTO> GetByState(string stage);
        IEnumerable<OrderDTO> GetByCity(string city);
        IEnumerable<OrderDTO> GetByZip(int zip);
        IEnumerable<OrderDTO> GetByCountry(string country);
    }
}
