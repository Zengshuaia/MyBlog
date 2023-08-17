using IRepository;
using MyBlog.Model;
using SqlSugar;
using SqlSugar.IOC;
using System.Linq.Expressions;

namespace Repository
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BaseRepository(ISqlSugarClient context = null) : base(context) 
        {
            base.Context = DbScoped.SugarScope;
            //创建库
            base.Context.DbMaintenance.CreateDatabase();
            //创建表
            base.Context.CodeFirst.InitTables(
                typeof(BlogNews),
                typeof(TypeInfo),
                typeof(WriteInfo)
                );
        }
        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await base.GetListAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetListAsync(func);
        }

        public Task<List<TEntity>> QueryAsync(int pageIndex, int pageSize, RefAsync<int> totalCount)
        {
            return base.Context.Queryable<TEntity>().ToPageListAsync(pageIndex, pageSize, totalCount);
        }
        public Task<List<TEntity>> QueryAsync(Expression<Func<TEntity,bool>> func,int pageIndex,int pageSize,RefAsync<int> totalCount)
        {
            return base.Context.Queryable<TEntity>().Where(func).ToPageListAsync( pageIndex, pageSize, totalCount);
        }
    }
}