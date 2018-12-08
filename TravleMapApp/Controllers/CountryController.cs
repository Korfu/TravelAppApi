using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravleMapApp.Dtos;

namespace TravleMapApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TravelDestinationDto>> Get()
        {
            return new List<TravelDestinationDto> {
                new TravelDestinationDto { Id=1,Name="Poland"},
                new TravelDestinationDto { Id=2, Name="China"},
                new TravelDestinationDto { Id=3, Name="Portugal"},
                new TravelDestinationDto { Id=4, Name="Spain" },
                new TravelDestinationDto { Id=5, Name="Sweden"}
            };
        }

        [HttpGet("{id}")]
        public ActionResult<TravelDestinationDto> Get(int id)
        {
            return new TravelDestinationDto { Id = 1, Name = "Poland" };
        }
    }
}