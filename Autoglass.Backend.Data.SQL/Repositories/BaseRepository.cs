using Autoglass.Backend.Data.SQL.Interfaces;
using Autoglass.Backend.Domain.Core.Entities;
using Autoglass.Backend.Domain.Core.Interfaces;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Backend.Data.SQL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IConnectionFactory _connectionFactory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            using var connection = _connectionFactory.GetOpenConnection();
            await connection.InsertAsync(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            using var connection = _connectionFactory.GetOpenConnection();
            await connection.DeleteAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var connection = _connectionFactory.GetOpenConnection();
            return await connection.GetAllAsync<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(long id)
        {
            using var connection = _connectionFactory.GetOpenConnection();
            return await connection.GetAsync<TEntity>(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using var connection = _connectionFactory.GetOpenConnection();
            await connection.UpdateAsync(entity);
        }
    }
}
