using Microsoft.AspNetCore.Mvc;
using RestApiNetCore9.Model;
using RestApiNetCore9.Services.Implementations;

namespace RestApiNetCore9.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet("FindAll")]
        public IActionResult FindAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("FindByID/{id}")]
        public IActionResult FindByID(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Create(person));
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Updade(person));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }

    }
}
