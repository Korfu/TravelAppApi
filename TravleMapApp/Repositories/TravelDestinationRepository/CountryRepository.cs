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

namespace TravleMapApp.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public CountryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["DefaultConnection"];
        }
        public TravelDestinationDto Get(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
                SELECT  [Id],
                        [Name]
                FROM [TravelMapAppDb].[dbo].[Countries]
                WHERE Id = @Id");
                command.Parameters.AddWithValue("Id", id); 
                var country = sqlConnection.QueryFirstOrDefault<TravelDestinationEntity>(command.CommandText, command.ToDynamicParameters());

                return TravelDestinationTransformator.Map(country);
            }

        }

        public IEnumerable<TravelDestinationDto> GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
                SELECT  [Id],
                        [Name]
                FROM [TravelMapAppDb].[dbo].[Countries]");
                var allCountries = sqlConnection.Query<TravelDestinationEntity>(command.CommandText, command.ToDynamicParameters()).ToList();

                return allCountries.Select(country => TravelDestinationTransformator.Map(country));
            }
        }
    }
}
