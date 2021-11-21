using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieListApi.DataAccess.Repositories.Shared
{
    public interface IRepositoryBase<TKey, TEntity> where TEntity: class
    {
        Task<TEntity> Get(TKey id);
        Task<IList<TEntity>> GetAll();
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}