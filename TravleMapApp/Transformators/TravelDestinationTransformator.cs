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
                Id = model.Id,
                Name = model.Name
            };
            return result;
        }

        public static TravelDestinationEntity Map(TravelDestinationDto model)
        {
            var result = new TravelDestinationEntity()
            {
                Id = model.Id,
                Name = model.Name
            };
            return result;
        }
    }
}
