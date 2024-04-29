using AutoMapper;
using DuckAPI.Dto;
using DuckAPI.Interfaces;
using DuckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckController : Controller
    {
        private readonly IDuckRepository _duckRepository;
        private readonly IMapper _mapper;
        public DuckController(IDuckRepository duckRepository, IMapper mapper)
        {
            _duckRepository = duckRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Duck>))]
        public IActionResult GetDucks()
        {
            var ducks = _mapper.Map<List<DuckDto>>(_duckRepository.GetDucks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(ducks);
        }

        [HttpGet("id/{DuckID}")]
        [ProducesResponseType(200, Type = typeof(Duck))]
        [ProducesResponseType(400)]
        public IActionResult GetDuckByID(int DuckID)
        {
            if (!_duckRepository.DuckExists(DuckID))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var duck = _mapper.Map<DuckDto>(_duckRepository.getDuckByID(DuckID));

            return Ok(duck);
        }

        //TODO:
        [HttpGet("name/{DuckName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetDuckByName(string DuckName)
        {
            if (!_duckRepository.DuckExists(DuckName))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Duck> ducks = _duckRepository.getDuckByName(DuckName);

            List<DuckDto> duckDtos = ducks.Select(duck => _mapper.Map<DuckDto>(duck)).ToList();

            return Ok(duckDtos);
        }
    }
}
