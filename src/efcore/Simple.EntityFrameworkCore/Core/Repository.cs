using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

using Simple.EntityFrameworkCore.Core.Base;

namespace Simple.EntityFrameworkCore.Core
{
    public class Repository<IDbcontext,TEntity> : IRepository<TEntity> 
        where TEntity : Entity
        where IDbcontext:MasterDbContext<IDbcontext>
    {
        public readonly IDbcontext _dbContext;
        private readonly DbSet<TEntity> DbSet;

        public Repository(IDbcontext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        ///<inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FirstOrDefaultAsync(
                x=> x.Id.Equals(id),cancellationToken:cancellationToken);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }
        ///<inheritdoc/>
        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }
        ///<inheritdoc/>
        public async Task DeleteManyAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var entities = await DbSet.Where(x=>ids.Contains(x.Id)).ToListAsync(cancellationToken:cancellationToken);
            if (entities.Count > 0)
            {
                DbSet.RemoveRange(entities);
            }
        }
        ///<inheritdoc/>
        public Task DeleteManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            DbSet.RemoveRange(entity);
            return Task.CompletedTask;
        }
        ///<inheritdoc/>
        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().FirstAsync(predicate, cancellationToken:cancellationToken);
        }
        ///<inheritdoc/>
        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken: cancellationToken);
        }
        ///<inheritdoc/>
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }
        ///<inheritdoc/>
        public async Task<IQueryable<TEntity>> GetQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(DbSet.AsNoTracking().Where(predicate));
        }
        ///<inheritdoc/>
        public async Task<IQueryable<TResult>> GetQueryAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return await Task.FromResult(DbSet.AsNoTracking().Where(predicate).Select(selector));
        }
        ///<inheritdoc/>
        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return (await DbSet.AddAsync(entity, cancellationToken)).Entity;
        }
        ///<inheritdoc/>
        public async Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
        }
        ///<inheritdoc/>
        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(predicate, cancellationToken)>0;
        }
        /// <inheritoc/>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return await Task.FromResult(entity);
        }

        ///<inheritdoc/>
        public Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }
    }
}
