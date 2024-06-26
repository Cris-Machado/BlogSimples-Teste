﻿using System.Linq.Expressions;

namespace BlogSimples.API.Domain.Interfaces.Repositories
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        #region ## CRUD
        Task<TEntity> InsertAsync(TEntity entity);
        Task<bool> InsertListAsync(IEnumerable<TEntity> listEntity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<bool> DeleteAsync(string id);
        #endregion

        #region ## Searches
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAsync(int skip, int take);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAllAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
