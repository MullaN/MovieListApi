using System;
using MovieListApi.DataAccess.Entities;
using MovieListApi.DataAccess.Repositories.Interfaces;
using MovieListApi.DataAccess.Repositories.Shared;

namespace MovieListApi.DataAccess.Repositories
{
    public class ListEntryRepository : RepositoryBase<Guid, ListEntryEntity>, IListEntryRepository
    {
        public ListEntryRepository(ConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }
    }
}