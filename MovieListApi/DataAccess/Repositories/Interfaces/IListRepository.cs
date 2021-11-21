using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieListApi.DataAccess.Entities;

namespace MovieListApi.DataAccess.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task<ListEntity> Get(Guid id);
        Task<IList<ListEntity>> GetAll();
        Task<bool> Insert(ListEntity entity);
        Task<bool> Update(ListEntity entity);
        Task<bool> Delete(ListEntity entity);
    }
}