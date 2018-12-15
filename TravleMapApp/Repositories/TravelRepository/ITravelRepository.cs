using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;

namespace TravleMapApp.Repositories.TravelRepository
{
    public interface ITravelRepository
    {
        void AddTravel(int userId, IEnumerable<TravelDestinationDto> visitedCountries);
        IEnumerable<TravelDestinationDto> GetTravelsForUser(int userId);
    }
}
