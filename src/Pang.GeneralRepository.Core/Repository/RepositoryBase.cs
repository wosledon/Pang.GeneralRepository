using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Core.Helper;

namespace Pang.GeneralRepository.Core.Repository
{
    /// <summary>
    /// 通用仓储基类
    /// </summary>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// </summary>
        public DbSet<T> DbSet { get; private set; }

        /// <summary>
        /// </summary>
        public GRCDbContext DbContext { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="context"> </param>
        public void Configure<TDbContext>(TDbContext context) where TDbContext : GRCDbContext
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            DbContext = context;
            DbSet = context.Set<T>();
        }

        /// <summary>
        /// </summary>
        /// <param name="context"> </param>
        public RepositoryBase(GRCDbContext context)
        {
            Configure(context);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public async Task InsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await DbSet.AddAsync(entity);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        public async Task InsertAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await DbSet.AddRangeAsync(entities);
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return await DbSet.Where(query).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return await DbSet.Where(query).ToListAsync();
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <param name="query">      查找条件 </param>
        /// <param name="pageNumber"> 页码 </param>
        /// <param name="pageSize">   每页大小 </param>
        /// <returns> </returns>
        public async Task<IEnumerable<T>> FindPagedListAsync(Expression<Func<T, bool>> query, int pageNumber, int pageSize)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return await PagedList<T>.CreateAsync((DbSet as IQueryable<T>).Where(query), pageNumber, pageSize);
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <param name="pageNumber"> 页码 </param>
        /// <param name="pageSize">   每页大小 </param>
        /// <returns> </returns>
        public async Task<IEnumerable<T>> FindPagedListAsync(int pageNumber, int pageSize)
        {
            return await PagedList<T>.CreateAsync(DbSet as IQueryable<T>, pageNumber, pageSize);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Task.Run(() =>
            {
                DbSet.UpdateRange(entities);
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        public async Task DeleteAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Task.Run(() =>
            {
                DbSet.RemoveRange(entities);
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        public async Task DeleteAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            await Task.Run(async () =>
            {
                DbSet.RemoveRange(await FindListAsync(query));
            });
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        /// <exception cref="ArgumentNullException"> </exception>
        /// <exception cref="NotImplementedException"> </exception>
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return await DbSet.AnyAsync(query);
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns> </returns>
        public async Task<bool> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync() >= 0;
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <typeparam name="TDbContext"> </typeparam>
    public class RepositoryBase<T, TDbContext> : IRepositoryBase<T, TDbContext> where T : class where TDbContext : GRCDbContext
    {
        /// <summary>
        /// </summary>
        public DbSet<T> DbSet { get; private set; }

        /// <summary>
        /// </summary>
        public TDbContext DbContext { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="context"> </param>
#pragma warning disable 693

        public void Configure(TDbContext context)
#pragma warning restore 693
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            DbContext = context;
            DbSet = context.Set<T>();
        }

        /// <summary>
        /// </summary>
        /// <param name="context"> </param>
        public RepositoryBase(TDbContext context)
        {
            Configure(context);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public async Task InsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await DbSet.AddAsync(entity);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        public async Task InsertAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await DbSet.AddRangeAsync(entities);
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return await DbSet.Where(query).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        public async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return await DbSet.Where(query).ToListAsync();
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <param name="query">      查找条件 </param>
        /// <param name="pageNumber"> 页码 </param>
        /// <param name="pageSize">   每页大小 </param>
        /// <returns> </returns>
        public async Task<IEnumerable<T>> FindPagedListAsync(Expression<Func<T, bool>> query, int pageNumber, int pageSize)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return await PagedList<T>.CreateAsync((DbSet as IQueryable<T>).Where(query), pageNumber, pageSize);
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <param name="pageNumber"> 页码 </param>
        /// <param name="pageSize">   每页大小 </param>
        /// <returns> </returns>
        public async Task<IEnumerable<T>> FindPagedListAsync(int pageNumber, int pageSize)
        {
            return await PagedList<T>.CreateAsync(DbSet as IQueryable<T>, pageNumber, pageSize);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Task.Run(() =>
            {
                DbSet.UpdateRange(entities);
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities"> </param>
        /// <returns> </returns>
        public async Task DeleteAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            await Task.Run(() =>
            {
                DbSet.RemoveRange(entities);
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        public async Task DeleteAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            await Task.Run(async () =>
            {
                DbSet.RemoveRange(await FindListAsync(query));
            });
        }

        /// <summary>
        /// 数据是否存在
        /// </summary>
        /// <param name="query"> </param>
        /// <returns> </returns>
        /// <exception cref="ArgumentNullException"> </exception>
        /// <exception cref="NotImplementedException"> </exception>
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return await DbSet.AnyAsync(query);
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns> </returns>
        public async Task<bool> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync() >= 0;
        }
    }
}