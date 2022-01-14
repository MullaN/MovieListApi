using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Humanizer;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MovieListApi.DataAccess.Repositories.Shared
{
    public class RepositoryBase<TKey, TEntity> : IRepositoryBase<TKey, TEntity> where TEntity: class
    {
        private readonly ConnectionFactory _connectionFactory;

        public RepositoryBase(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public virtual async Task<TEntity> Get(TKey id)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return await connection.GetAsync<TEntity>(id);
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return (await connection.GetAllAsync<TEntity>()).ToList();
        }

        public virtual async Task<bool> Insert(TEntity entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            var result = await connection.ExecuteAsync(GenerateInsert(entity));
            return result > 0;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return await connection.UpdateAsync<TEntity>(entity);
        }

        public virtual async Task<bool> Delete(TEntity entity)
        {
            using var connection = _connectionFactory.CreateConnection();
            connection.Open();
            return await connection.DeleteAsync<TEntity>(entity);
        }

        private string GenerateInsert(TEntity entity)
        {
            
            var tableName = typeof(TEntity).Name.ToLower().Replace("entity", "").Pluralize();
            var columnNames = new List<string>();
            var values = new List<string>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (property.HasAttribute<WriteAttribute>())
                {
                    continue;
                }

                if (property.GetValue(entity) == null)
                {
                    continue;
                }
                
                columnNames.Add(property.Name.ToLower());
                var stringValue = property.PropertyType == typeof(string)
                    ? $"\'{((string) property.GetValue(entity)).Replace("'", "''")}\'"
                    : $"{property.GetValue(entity)}";
                if (property.PropertyType == typeof(Guid))
                {
                    stringValue = "\'" + stringValue + "\'";
                }
                values.Add(stringValue);
            }

            return $"INSERT INTO {tableName}({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)});";
        }
    }
}