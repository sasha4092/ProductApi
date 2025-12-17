using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductInfo request)
        {
            _service.AddProduct(request);
            return Ok(new { success = true, message = "Product processed successfully" });
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_service.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
