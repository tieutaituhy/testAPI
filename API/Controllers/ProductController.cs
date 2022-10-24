using API.Model;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow.CommonModels;

namespace API.Controllers
{
    [Route("API/[Controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }



        [HttpGet("{Id}")]
        public IActionResult GetById(string Id)
        {
            try
            {
                var hh = products.SingleOrDefault(h => h.ProductId == Guid.Parse(Id));
                if (hh == null)
                {
                    return NotFound();
                }
                return Ok(hh);
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var hh = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productVM.ProductName,
                Price = productVM.Price
            };
            products.Add(hh);
            return Ok(new
            {
                Success = true,
                Data = products
            });
        }


        [HttpPut("{Id}")]
        public IActionResult Edit(string Id, Product Edit)
        {
            try
            {
                var hh = products.SingleOrDefault(h => h.ProductId == Guid.Parse(Id));
                if (hh == null)
                {
                    return NotFound();
                }
                if(Id != hh.ProductId.ToString())
                {
                    return BadRequest();
                }
                hh.ProductName = Edit.ProductName;
                hh.Price = Edit.Price;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(string Id)
        {
            try
            {
                var hh = products.SingleOrDefault(h => h.ProductId == Guid.Parse(Id));
                if (hh == null)
                {
                    return NotFound();
                }
                products.Remove(hh);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
