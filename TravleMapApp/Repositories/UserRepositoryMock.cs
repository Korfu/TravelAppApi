using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;
using TravleMapApp.Entities;
using TravleMapApp.Transformators;

namespace TravleMapApp.Repositories
{
    public class UserRepositoryMock : IUserRepository
    {
        public static List<UserEntity> _allUsers = new List<UserEntity> {
        new UserEntity {
             FirstName="Konrad",
             LastName="Korf",
             Id=1,
             VisitedCountries= new List<TravelDestinationEntity>
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
                     },
                 }
             },
        new UserEntity {
             FirstName="Martyna",
             LastName="Zajączkowska",
             Id=2,
             VisitedCountries= new List<TravelDestinationEntity>
                 {
                     new TravelDestinationEntity
                     {
                        Id=1,
                        Name="Poland"
                     }
                 }
            },
        };

        public IEnumerable<UserDto> GetAll()
        {
            return _allUsers.Select((userDto) => UserTransformator.Map(userDto));
        }

        public UserDto Get(int id)
        {
            var user = _allUsers.SingleOrDefault(x => x.Id == id);
            return UserTransformator.Map(user);
        }

        public int Add(UserDto user)
        {
            var userToAdd = new UserDto
            {
                Id = _allUsers.Max(x => x.Id) + 1,
                FirstName = user.FirstName,
                LastName = user.LastName,
                VisitedCountries = user.VisitedCountries.Select(y => new TravelDestinationDto
                {
                    Id = y.Id,
                    Name = y.Name
                }).ToList()
            };

            _allUsers.Add(UserTransformator.Map(userToAdd));

            return userToAdd.Id;
        }

        public void Edit(UserDto user)
        {
            var originalUser = _allUsers.Find(x => x.Id == user.Id);
            UserTransformator.Map(originalUser);
        }

        public void Delete(UserDto user)
        {
            var userToDelete = _allUsers.Find(x => x.Id == user.Id);
            _allUsers.Remove(userToDelete);
        }
    }
}
