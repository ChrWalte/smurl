using Dapper;
using Npgsql;
using smurl.data.Interfaces;
using smurl.domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smurl.data.Repositories
{
    public class ClickRepository : IClickRepository
    {
        private readonly string _connectionString;

        public ClickRepository(DatabaseConfiguration databaseConfiguration)
        {
            _connectionString = databaseConfiguration.ConnectionString;
        }

        public async Task<List<Click>> GetClicksAsync(Guid linkIdentifier)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<List<Click>>(SqlCommand.GetClicks, new { LinkIdentifier  = linkIdentifier });
        }

        public async Task<Click> CreateClickAsync(Click click)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Click>(SqlCommand.CreateClick, click);
        }

        public async Task<Click> UpdateClickAsync(Click click)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Click>(SqlCommand.UpdateClick, click);
        }

        public async Task<Click> DeleteClickAsync(Guid identifier)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Click>(SqlCommand.DeleteClick, new { Identifier = identifier });
        }
    }
}