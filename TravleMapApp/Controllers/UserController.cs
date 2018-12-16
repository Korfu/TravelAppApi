using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Controllers.ControllerParams;
using TravleMapApp.Dtos;
using TravleMapApp.Repositories;
using TravleMapApp.Repositories.TravelRepository;

namespace TravleMapApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITravelRepository _travelRepository;

        public UserController(IUserRepository userRepository,
                              ICountryRepository countryRepository,
                              ITravelRepository travelRepository)
        {
            _userRepository = userRepository;
            _countryRepository = countryRepository;
            _travelRepository = travelRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            var users = _userRepository.GetAll();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();
            };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var user = _userRepository.Get(id);
            user.VisitedCountries = _travelRepository.GetTravelsForUser(id).ToList();  
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] AddUserParam param)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddUser(param);
                var userId = _userRepository.GetAll().Max(u => u.Id);
                _travelRepository.AddTravel(userId, param.VisitedCountries);

                var userToView = new UserDto
                {
                    Id = userId,
                    FirstName = param.FirstName,
                    LastName = param.LastName,
                    VisitedCountries = param.VisitedCountries
                };
                return Ok(userToView);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Edit([FromBody]UserDto user)
        {
            if (ModelState.IsValid)
            {
                var userToBeEdited = _userRepository.Get(user.Id);
                if (userToBeEdited != null)
                {
                    return Ok(userToBeEdited);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.Get(id);
                _travelRepository.DeleteTravelsForUser(id);
                if (user != null)
                {
                    _userRepository.Delete(user);
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
