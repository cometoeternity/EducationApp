using EducationalApp.Model.Models;
using System;
using System.Collections.Generic;

namespace EducationalApp.Service.Interfaces
{
    public interface IProductService
    {
        Product CreateProduct(Product product);
        Product GetProductByName(string name);
        Product GetProductByCategory(string category);
        void UpdateProduct(Product product);
        void EditProduct(Guid id, string name, string description, string category, decimal price);
        IEnumerable<Product> GetProducts();
        void DeleteProduct(Guid id);
        void SaveProduct();
    }
}
