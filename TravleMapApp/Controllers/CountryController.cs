using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravleMapApp.Dtos;
using TravleMapApp.Repositories;

namespace TravleMapApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ITravelDestinationRepository _travelDestinationRepository;

        public CountryController(ITravelDestinationRepository travelDestinationRepository)
        {
            _travelDestinationRepository = travelDestinationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TravelDestinationDto>> Get()
        {
            var countries = _travelDestinationRepository.GetAll();
            if (countries != null)
            {
                return Ok(countries);
            } else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TravelDestinationDto> Get(int id)
        {
            var country = _travelDestinationRepository.Get(id);
            if (country != null)
            {
                return Ok(country);
            }
            else
            {
                return NotFound();
            }
        }
    }
}