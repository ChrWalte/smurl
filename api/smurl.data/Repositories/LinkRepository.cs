using Dapper;
using Npgsql;
using smurl.data.Interfaces;
using smurl.domain.Entities;
using System;
using System.Threading.Tasks;

namespace smurl.data.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly string _connectionString;

        public LinkRepository(DatabaseConfiguration databaseConfiguration)
        {
            _connectionString = databaseConfiguration.ConnectionString;
        }

        public async Task<Link> GetLinkAsync(string slug)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Link>(SqlCommand.GetLink, new { Slug = slug });
        }

        public async Task<Link> CreateLinkAsync(Link link)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Link>(SqlCommand.CreateLink, link);
        }

        public async Task<Link> UpdateLinkAsync(Link link)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Link>(SqlCommand.UpdateLink, link);
        }

        public async Task<Link> DeleteLinkAsync(Guid identifier)
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Link>(SqlCommand.DeleteLink, new { Identifier = identifier });
        }
    }
}