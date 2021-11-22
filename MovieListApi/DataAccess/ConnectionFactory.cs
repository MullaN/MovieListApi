using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace MovieListApi.DataAccess
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetValue<string>("Values:SqlConnection");
        }
        
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}