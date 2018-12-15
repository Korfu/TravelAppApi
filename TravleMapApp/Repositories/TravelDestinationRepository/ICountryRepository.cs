using System.Collections.Generic;
using TravleMapApp.Dtos;

namespace TravleMapApp.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<TravelDestinationDto> GetAll();
        TravelDestinationDto Get(int id);
    }
}
