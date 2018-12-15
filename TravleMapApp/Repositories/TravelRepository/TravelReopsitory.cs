using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TravleMapApp.Dtos;
using TravleMapApp.Entities;
using TravleMapApp.Helpers;
using TravleMapApp.Transformators;

namespace TravleMapApp.Repositories.TravelRepository
{
    public class TravelReopsitory : ITravelRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public TravelReopsitory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["DefaultConnection"];
        }

        public void AddTravel(int userId, IEnumerable<TravelDestinationDto> travels)
        {
            foreach (var travel in travels)
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand(@"
                     INSERT INTO Travels (UserId, CountryId)
                      VALUES (@UserId, @CountryId)");
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@CountryId", travel.Id);

                    sqlConnection.Execute(command.CommandText, command.ToDynamicParameters());
                }
            }
        }

        public IEnumerable<TravelDestinationDto> GetTravelsForUser(int userId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
                  SELECT CountryId, Name
                  FROM VisitedCountries
                WHERE UserId = @UserId");
                command.Parameters.AddWithValue("UserId", userId);
                var visitedCountries = sqlConnection.Query<TravelDestinationEntity>(command.CommandText, command.ToDynamicParameters());

                return visitedCountries.Select(country => TravelDestinationTransformator.Map(country));
            }
        }
    }
}
