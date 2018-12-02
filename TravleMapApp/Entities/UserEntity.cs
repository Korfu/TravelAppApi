using System.Collections.Generic;

namespace TravleMapApp.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<TravelDestinationEntity> VisitedCountries { get; set; }
    }
}
