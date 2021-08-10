using EducationalApp.Data;
using EducationalApp.Data.Infrastructure;
using EducationalApp.Data.Repository;
using EducationalApp.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private UnitOfWork<ApplicationDbContext> _unitOfWork;
        private Repository<Product> _repository;
        private IProductRepository _productRepository;

        public ProductController(UnitOfWork<ApplicationDbContext> unitOfWork, ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repository = new Repository<Product>(_unitOfWork);
            _productRepository = new ProductRepository(_unitOfWork);
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() => _repository.GetAll().ToList();

        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return product;
        }
    

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                _unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    _repository.Insert(product);
                    _unitOfWork.Save();
                    _unitOfWork.Commit();
                    return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
                }
            }
            catch (Exception /*ex*/)
            {
                _unitOfWork.Rollback();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Product product)
        {
            if (id != product.Id) return BadRequest();

            var existingProduct = _repository.GetById(id);
            if (existingProduct is null) return NotFound();

            _repository.Update(product);
            _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
