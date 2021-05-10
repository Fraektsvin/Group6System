using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseTier.Models;

namespace DatabaseTier.Repository
{
    public interface IRepository<TEntity> where TEntity:class 
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(int predicate);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> GetAsync(TEntity entity);
    }
}