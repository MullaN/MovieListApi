using System;
using MovieListApi.DataAccess.Entities;
using MovieListApi.DataAccess.Repositories.Interfaces;
using MovieListApi.DataAccess.Repositories.Shared;

namespace MovieListApi.DataAccess.Repositories
{
    public class ListRepository : RepositoryBase<Guid, ListEntity>, IListRepository
    {
        public ListRepository(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}