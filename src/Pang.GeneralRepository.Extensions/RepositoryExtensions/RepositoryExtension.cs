using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Helper;
using Pang.GeneralRepository.Core.Repository;

namespace Pang.GeneralRepository.Extensions.RepositoryExtensions
{
    /// <summary>
    /// 仓储的扩展方法
    /// </summary>
    public static class RepositoryExtension
    {
        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> FindPagedListAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            return await PagedList<T>.CreateAsync(query.Where(expression));
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="expression"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> FindPagedListAsync<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression, int pageNumber, int pageSize)
        {
            return await PagedList<T>.CreateAsync(query.Where(expression), pageNumber, pageSize);
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> FindPagedListAsync<T>(this IQueryable<T> query)
        {
            return await PagedList<T>.CreateAsync(query);
        }

        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> FindPagedListAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return await PagedList<T>.CreateAsync(query, pageNumber, pageSize);
        }


        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="repos"> </param>
        /// <param name="query"> </param>
        /// <typeparam name="T"> </typeparam>
        /// <typeparam name="TDbContext"> </typeparam>
        /// <typeparam name="TModel"> </typeparam>
        /// <returns> </returns>
        public static IQueryable<T> Include<T, TDbContext, TModel>(this IRepositoryBase<T, TDbContext> repos, Expression<Func<T, ICollection<TModel>>> query) where T : class
        {
           return repos.DbSet.Include(query);
        }

        ///// <summary>
        ///// </summary>
        ///// <param name="repos"> </param>
        ///// <param name="query"> </param>
        ///// <typeparam name="T"> </typeparam>
        ///// <typeparam name="TModel"> </typeparam>
        ///// <returns> </returns>
        //public static IQueryable<T> Include<T, TModel>(this IQueryable<T> repos, Expression<Func<T, ICollection<TModel>>> query) where T : class
        //{
        //    return repos.Include(query);
        //}

        ///// <summary>
        ///// </summary>
        ///// <param name="repos"> </param>
        ///// <param name="query"> </param>
        ///// <typeparam name="T"> </typeparam>
        ///// <typeparam name="TModel"> </typeparam>
        ///// <returns> </returns>
        //public static IQueryable<T> ThenInclude<T, TModel>(this IQueryable<T> repos, Expression<Func<T, ICollection<TModel>>> query) where T : class
        //{
        //    return repos.ThenInclude(query);
        //}
    }
}