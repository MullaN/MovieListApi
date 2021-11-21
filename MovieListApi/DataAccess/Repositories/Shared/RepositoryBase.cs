using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace MovieListApi.DataAccess.Repositories.Shared
{
    public class RepositoryBase<TKey, TEntity> : IRepositoryBase<TKey, TEntity> where TEntity: class
    {
        private readonly ConnectionFactory _connectionFactory;

        public RepositoryBase(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<TEntity> Get(TKey id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return await connection.GetAsync<TEntity>(id);
        }

        public async Task<IList<TEntity>> GetAll()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return (await connection.GetAllAsync<TEntity>()).ToList();
        }

        public async Task<bool> Insert(TEntity entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            var result = await connection.InsertAsync<TEntity>(entity);
            return result > 0;
        }

        public async Task<bool> Update(TEntity entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return await connection.UpdateAsync<TEntity>(entity);
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return await connection.DeleteAsync<TEntity>(entity);
        }
    }
}