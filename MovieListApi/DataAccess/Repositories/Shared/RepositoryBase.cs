using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
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
            var result = await connection.ExecuteAsync(GenerateInsert(entity));
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

        private string GenerateInsert(TEntity entity)
        {
            var tableName = typeof(TEntity).Name.ToLower().Replace("entity", "s");
            var columnNames = new List<string>();
            var values = new List<string>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                columnNames.Add(property.Name.ToLower());
                var stringValue = property.PropertyType == typeof(string)
                    ? $"\'{((string) property.GetValue(entity)).Replace("'", "''")}'"
                    : $"{property.GetValue(entity)}";
                values.Add(stringValue);
            }

            return $"INSERT INTO {tableName}({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)});";
        }
    }
}