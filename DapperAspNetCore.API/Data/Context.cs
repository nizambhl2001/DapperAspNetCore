using System.Data;
using System.Data.SqlClient;

namespace DapperAspNetCore.API.Data
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnecitonSetting");
        }
        public IDbConnection CreateConnectionString() => new SqlConnection(_connectionString);
    }
}
