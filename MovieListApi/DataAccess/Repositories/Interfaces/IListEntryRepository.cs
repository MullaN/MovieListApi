using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieListApi.DataAccess.Entities;

namespace MovieListApi.DataAccess.Repositories.Interfaces
{
    public interface IListEntryRepository
    {
        Task<ListEntryEntity> Get(Guid id);
        Task<IList<ListEntryEntity>> GetAll();
        Task<bool> Insert(ListEntryEntity entity);
        Task<bool> Update(ListEntryEntity entity);
        Task<bool> Delete(ListEntryEntity entity);
    }
}