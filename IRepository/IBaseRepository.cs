using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class,new()//约束泛型必须是应用类型，必须有一个构造函数
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> EditAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        /// <summary>
        /// 查询全部的数据
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync();
        /// <summary>
        /// 自定义条件查询
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);
        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(int pageIndex, int pageSize, RefAsync<int> totalCount);
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity,bool>> func,int pageIndex,int pageSize,RefAsync<int> totalCount);
    }
}
