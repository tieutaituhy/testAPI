using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;
        public TypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        //public TypeRepository TypeRepository { get; set; }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_typeRepository.GetAllTypes());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                var type = _typeRepository.GetById(Id);
                if (type != null)
                {
                    return Ok(type);
                }
                return NotFound();
                //return Ok(_typeRepository.GetById(Id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Update(TypeVM type, int Id)
        {
            if(Id != type.TypeId)
            {
                return BadRequest();
            }
            try
            {
                _typeRepository.Update(type);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _typeRepository.Delete(Id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(TypeModel model)
        {
            try
            {
                var types = _typeRepository.Add(model);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
