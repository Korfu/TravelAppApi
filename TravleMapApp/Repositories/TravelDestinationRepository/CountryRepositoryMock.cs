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
                CountryId=1,
                Name="Poland"
            },
            new TravelDestinationEntity
            {
               CountryId=2,
                Name="USA"
            },
            new TravelDestinationEntity
            {
                CountryId=3,
                Name="Argentina"
            }
        };

        public TravelDestinationDto Get(int id)
        {
            var result = _allTravelDestinations.First(x => x.CountryId == id);
            return TravelDestinationTransformator.Map(result);
        }

        public IEnumerable<TravelDestinationDto> GetAll()
        {
            return _allTravelDestinations.Select((destination) => TravelDestinationTransformator.Map(destination));
        }
    }
}

