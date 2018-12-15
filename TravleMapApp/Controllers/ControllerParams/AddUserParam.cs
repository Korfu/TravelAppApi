using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;

namespace TravleMapApp.Controllers.ControllerParams
{
    public class AddUserParam
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<TravelDestinationDto> VisitedCountries { get; set; }
    }
}
