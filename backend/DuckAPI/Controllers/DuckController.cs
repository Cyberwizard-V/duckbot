using DuckAPI.Interfaces;
using DuckAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckController : Controller
    {
        private readonly IDuckRepository _duckRepository;
        public DuckController(IDuckRepository duckRepository)
        {
            _duckRepository = duckRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Duck>))]
        public IActionResult GetDucks()
        {
            var ducks = _duckRepository.GetDucks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ducks);
        }
    }
}
