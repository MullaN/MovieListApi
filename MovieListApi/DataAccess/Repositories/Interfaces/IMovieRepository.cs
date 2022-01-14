using System.Collections.Generic;
using System.Threading.Tasks;
using MovieListApi.DataAccess.Entities;

namespace MovieListApi.DataAccess.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<MovieEntity> Get(string id);
        Task<IList<MovieEntity>> GetAll();
        Task<bool> Insert(MovieEntity entity);
        Task<bool> Update(MovieEntity entity);
        Task<bool> Delete(MovieEntity entity);
        Task<IList<MovieEntity>> Search(string queryString);
    }
}