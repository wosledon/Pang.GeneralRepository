using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Core.Helper;

namespace Pang.GeneralRepository.Core.Repository
{
    /// <summary>
    /// 通用仓储接口初始化基类
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public static GRCDbContext DbContext { get; set; }

        /// <summary>
        /// 配置通用仓储
        /// </summary>
        /// <typeparam name="TDbContext"> </typeparam>
        /// <param name="context"> </param>
        //void Configure<TDbContext>(TDbContext context) where TDbContext : DbContext;

        public void Configure<TDbContext>(TDbContext context) where TDbContext : GRCDbContext
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <returns> </returns>
        public static GRCDbContext GetDbContext()
        {
            return DbContext;
        }
    }

    /// <summary>
    /// 通用仓储接口
    /// </summary>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Table
        /// </summary>
        DbSet<T> DbSet { get; }

        /// <summary>
        /// </summary>
        new GRCDbContext DbContext => IRepositoryBase.GetDbContext();

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        Task InsertAsync(IEnumerable<T> entities);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns> </returns>
        Task<T> FindAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<T>> FindPagedListAsync(int pageNumber, int pageSize);

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<T>> FindPagedListAsync(Expression<Func<T, bool>> query, int pageNumber, int pageSize);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        Task UpdateAsync(IEnumerable<T> entities);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        Task DeleteAsync(IEnumerable<T> entities);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        Task DeleteAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns> </returns>
        Task<bool> SaveChangesAsync();
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <typeparam name="TDbContext"> </typeparam>
    public interface IRepositoryBase<T, TDbContext> where T : class
    {
        /// <summary>
        /// Table
        /// </summary>
        DbSet<T> DbSet { get; }

        /// <summary>
        /// </summary>
        TDbContext DbContext { get; }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        Task InsertAsync(IEnumerable<T> entities);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns> </returns>
        Task<T> FindAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<T>> FindPagedListAsync(int pageNumber, int pageSize);

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <returns> </returns>
        Task<IEnumerable<T>> FindPagedListAsync(Expression<Func<T, bool>> query, int pageNumber, int pageSize);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        Task UpdateAsync(IEnumerable<T> entities);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        Task DeleteAsync(IEnumerable<T> entities);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        Task DeleteAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> query);

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns> </returns>
        Task<bool> SaveChangesAsync();
    }
}