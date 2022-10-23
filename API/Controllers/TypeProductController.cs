using API.Data;
using API.Helpers;
using API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class TypeProductController : Controller
    {
        private readonly DataContext _context;

        public TypeProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var ListType = _context.TypeProducts.ToList();
                return Ok(ListType);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var ListType = _context.TypeProducts.SingleOrDefault(l => l.TypeId == Id);
            if (ListType != null)
            {
                return Ok(ListType);
            }
            return NotFound();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Create(TypeModel model)
        {
            try
            {
                var type = new TypeProduct
                {
                    TypeName = model.TypeName,
                };
                _context.Add(type);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, type);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("{Id}")]
        public IActionResult Update(int Id, TypeModel model)
        {
            var ListType = _context.TypeProducts.SingleOrDefault(l => l.TypeId == Id);
            if (ListType != null)
            {
                ListType.TypeName = model.TypeName;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteById(int Id)
        {
            var ListType = _context.TypeProducts.SingleOrDefault(l => l.TypeId == Id);
            if (ListType != null)
            {
                _context.Remove(ListType);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            return NotFound();
        }
    }
}
