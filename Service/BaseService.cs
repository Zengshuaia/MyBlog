using IRepository;
using IService;
using SqlSugar;
using System.Linq.Expressions;

namespace Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        protected IBaseRepository<TEntity> _iBaseRepository;
        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await _iBaseRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _iBaseRepository.DeleteAsync(id);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await _iBaseRepository.EditAsync(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _iBaseRepository.FindAsync(id);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await _iBaseRepository.QueryAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _iBaseRepository.QueryAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync(int pageIndex, int pageSize, RefAsync<int> totalCount)
        {
            return await _iBaseRepository.QueryAsync(pageIndex, pageSize, totalCount);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int pageIndex, int pageSize, RefAsync<int> totalCount)
        {
            return await _iBaseRepository.QueryAsync(func, pageIndex, pageSize, totalCount);
        }
    }
}