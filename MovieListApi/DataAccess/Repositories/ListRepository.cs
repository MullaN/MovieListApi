using System.Linq;
using Dapper;
using MovieListApi.DataAccess.Repositories.Shared;

namespace MovieListApi.DataAccess.Repositories
{
    public class ListRepository : RepositoryBase<Guid, ListEntity>, IListRepository
    {
        private readonly ConnectionFactory _connectionFactory;
        
        public ListRepository(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public override async Task<ListEntity> Get(Guid id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            using var multi = await connection.QueryMultipleAsync(@"
SELECT * FROM lists
WHERE listid = @id;

SELECT movies.* FROM lists
INNER JOIN listentries ON lists.listid = listentries.listid
INNER JOIN movies ON listentries.movieid = movies.imdbid
WHERE lists.listid = @id;
", new { id });
            var list = (await multi.ReadAsync<ListEntity>()).First();
            var movies = await multi.ReadAsync<MovieEntity>();
            list.Movies = movies.ToList();
            return list;
        }
    }
}