using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;

namespace TravleMapApp.Repositories
{
    public interface IUserRepository
    {
        UserDto Get(int id);
        IEnumerable<UserDto> GetAll();
        int Add(UserDto user);
        void Edit(UserDto user);
        void Delete(UserDto user);
    }
}
