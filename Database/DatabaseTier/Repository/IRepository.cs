using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatabaseTier.Repository
{
    public interface IRepository<TEntity> where TEntity:class 
    {
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(int predicate);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}