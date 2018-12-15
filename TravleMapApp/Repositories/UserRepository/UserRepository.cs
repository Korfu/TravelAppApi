using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TravleMapApp.Dtos;
using TravleMapApp.Entities;
using TravleMapApp.Helpers;
using TravleMapApp.Transformators;

namespace TravleMapApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["DefaultConnection"];
        }

        public int Add(UserDto user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
                  INSERT INTO Users (Id, FirstName, LastName)
                  VALUES (@Id, @FirstName, @Lastname)");
                  command.Parameters.AddWithValue("@Id", user.Id);
                  command.Parameters.AddWithValue("@FirstName", user.FirstName);
                  command.Parameters.AddWithValue("@LastName", user.LastName);

                sqlConnection.Execute(command.CommandText, command.ToDynamicParameters());

                return user.Id;
            }
        }
        public void Delete(UserDto user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
                 DELETE FROM Travels WHERE UserId=@Id;
                 DELETE FROM Users WHERE Id=@Id;");
                command.Parameters.AddWithValue("@Id", user.Id);

                sqlConnection.Execute(command.CommandText, command.ToDynamicParameters());
            }
        }

        public void Edit(UserDto user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
                    UPDATE Users
                    SET FirstName = @FirstName, LastName = @LastName
                    WHERE Id =@Id");
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);

                sqlConnection.Execute(command.CommandText, command.ToDynamicParameters());
            }
        }

        public UserDto Get(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = new SqlCommand(@"
                SELECT [Id],
                       [FirstName],
                       [LastName]
                FROM [TravelMapAppDb].[dbo].[Users]
                WHERE @Id = Id");
                query.Parameters.AddWithValue("Id", id);
                var user = sqlConnection.QueryFirstOrDefault<UserEntity>(query.CommandText, query.ToDynamicParameters());

                return UserTransformator.Map(user);
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = new SqlCommand(@"
                SELECT [Id],
                       [FirstName],
                       [LastName]
                FROM [TravelMapAppDb].[dbo].[Users]");
                var allUsers = sqlConnection.Query<UserEntity>(query.CommandText, query.ToDynamicParameters()).ToList();

                return allUsers.Select(user => UserTransformator.Map(user));
            }
        }
    }
}
