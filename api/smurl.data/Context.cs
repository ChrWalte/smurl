using Npgsql;
using smurl.data.Interfaces;
using System;
using System.Threading.Tasks;

namespace smurl.data
{
    public class Context : IContext
    {
        private readonly string _connectionString;

        public Context(DatabaseConfiguration databaseConfiguration)
        {
            _connectionString = databaseConfiguration.ConnectionString;
        }

        public async Task TestDatabaseConnection()
        {
            try
            {
                await using var connection = new NpgsqlConnection(_connectionString);
                await connection.OpenAsync();
                var version = connection.PostgreSqlVersion;
                Console.WriteLine($"Postgres Version: {version}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}