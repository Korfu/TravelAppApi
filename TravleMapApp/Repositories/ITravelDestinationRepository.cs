using System.Collections.Generic;
using TravleMapApp.Dtos;

namespace TravleMapApp.Repositories
{
    public interface ITravelDestinationRepository
    {
        IEnumerable<TravelDestinationDto> GetAll();
        TravelDestinationDto Get(int id);
    }
}
