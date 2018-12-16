using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;
using TravleMapApp.Entities;

namespace TravleMapApp.Transformators
{
    public class TravelDestinationTransformator
    {
        public static TravelDestinationDto Map(TravelDestinationEntity model)
        {
            var result = new TravelDestinationDto()
            {
                CountryId = model.CountryId,
                Name = model.Name
            };
            return result;
        }

        public static TravelDestinationEntity Map(TravelDestinationDto model)
        {
            var result = new TravelDestinationEntity()
            {
                CountryId = model.CountryId,
                Name = model.Name
            };
            return result;
        }
    }
}
