using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult GetAllProducts(string seach)
        {
            try
            {
                var result = _productRepository.GetAll(seach);
                return Ok(result);
            }
            catch
            {
                return BadRequest("...");
            }
        }
    }
}
