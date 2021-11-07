using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Repository;

namespace Pang.GeneralRepository.Extensions.RepositoryExtensions
{
    /// <summary>
    /// 仓储的扩展方法
    /// </summary>
    public static class RepositoryExtension
    {
        /// <summary>
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

        /// <summary>
        /// </summary>
        /// <param name="repos"> </param>
        /// <param name="query"> </param>
        /// <typeparam name="T"> </typeparam>
        /// <typeparam name="TModel"> </typeparam>
        /// <returns> </returns>
        public static IQueryable<T> Include<T, TModel>(this IQueryable<T> repos, Expression<Func<T, ICollection<TModel>>> query) where T : class
        {
            return repos.Include(query);
        }

        /// <summary>
        /// </summary>
        /// <param name="repos"> </param>
        /// <param name="query"> </param>
        /// <typeparam name="T"> </typeparam>
        /// <typeparam name="TModel"> </typeparam>
        /// <returns> </returns>
        public static IQueryable<T> ThenInclude<T, TModel>(this IQueryable<T> repos, Expression<Func<T, ICollection<TModel>>> query) where T : class
        {
            return repos.ThenInclude(query);
        }
    }
}