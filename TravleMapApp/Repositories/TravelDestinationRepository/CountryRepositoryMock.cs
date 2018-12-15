using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;
using TravleMapApp.Entities;
using TravleMapApp.Transformators;

namespace TravleMapApp.Repositories
{
    public class CountryRepositoryMock : ICountryRepository
    {
        private List<TravelDestinationEntity> _allTravelDestinations = new List<TravelDestinationEntity>
        {
            new TravelDestinationEntity
            {
                Id=1,
                Name="Poland"
            },
            new TravelDestinationEntity
            {
                Id=2,
                Name="USA"
            },
            new TravelDestinationEntity
            {
                Id=3,
                Name="Argentina"
            }
        };

        public TravelDestinationDto Get(int id)
        {
            var result = _allTravelDestinations.First(x => x.Id == id);
            return TravelDestinationTransformator.Map(result);
        }

        public IEnumerable<TravelDestinationDto> GetAll()
        {
            return _allTravelDestinations.Select((destination) => TravelDestinationTransformator.Map(destination));
        }
    }
}

