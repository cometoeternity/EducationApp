using EducationalApp.Common.DTO;
using EducationalApp.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationalApp.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IService<ProductDTO> _productService;

        public ProductController(IService<ProductDTO> productService)
        {
            _productService = productService;
        }

        public IActionResult List() => View(_productService.GetAll());
    }
}
