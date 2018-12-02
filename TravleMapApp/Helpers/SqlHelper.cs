using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace TravleMapApp.Helpers
{
    public static class SqlHelper
    {
        public static DynamicParameters ToDynamicParameters(this IDbCommand command)
        {
            var args = new DynamicParameters(new { });
            foreach (SqlParameter item in command.Parameters)
            {
                args.Add(item.ParameterName, item.Value);
            }

            return args;
        }
    }
}
