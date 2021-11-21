using MovieListApi.DataAccess.Entities;
using MovieListApi.DataAccess.Repositories.Interfaces;
using MovieListApi.DataAccess.Repositories.Shared;

namespace MovieListApi.DataAccess.Repositories
{
    public class MovieRepository : RepositoryBase<string, MovieEntity>, IMovieRepository
    {
        public MovieRepository(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}