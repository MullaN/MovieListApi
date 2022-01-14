using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Connections;
using MovieListApi.DataAccess.Entities;
using MovieListApi.DataAccess.Repositories.Interfaces;
using MovieListApi.DataAccess.Repositories.Shared;

namespace MovieListApi.DataAccess.Repositories
{
    public class MovieRepository : RepositoryBase<string, MovieEntity>, IMovieRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        
        public MovieRepository(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IList<MovieEntity>> Search(string queryString)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();

            var sql = $@"
SELECT * FROM movielistdb.public.movies
WHERE title ILIKE '%{queryString}%';
";
            var result = (await connection.QueryAsync<MovieEntity>(sql)).ToList();
            return result;
        }
    }
}