using EducationalApp.Common.DTO;
using System;

namespace EducationalApp.Model.Interfaces
{
    public interface IProductService : IService<ProductDTO>
    {
        ProductDTO GetProductByName(string name);
        ProductDTO GetProductByCategory(string category);
        void EditProduct(Guid id, string name, string description, string category, decimal price);
    }
}
