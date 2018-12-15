using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;
using TravleMapApp.Entities;

namespace TravleMapApp.Transformators
{
    public class UserTransformator
    {
        public static UserDto Map(UserEntity model)
        {
            var result = new UserDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id,
                VisitedCountries = model?.VisitedCountries?.Select(y => new TravelDestinationDto
                {
                    Id = y.Id,
                    Name = y.Name
                })
            };

            return result;
        }

        public static UserEntity Map(UserDto model)
        {
            var result = new UserEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Id = model.Id,
                VisitedCountries = model.VisitedCountries.Select(y => new TravelDestinationEntity
                {
                    Id = y.Id,
                    Name = y.Name
                })
            };

            return result;
        }
    }
}
