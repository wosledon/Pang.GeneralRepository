using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pang.GeneralRepository.Core.Helper
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// 每页大小
        /// </summary>
        private int PageSize { get; set; }

        /// <summary>
        /// 总数据数
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;

        /// <summary>
        /// </summary>
        /// <param name="items">      </param>
        /// <param name="count">      </param>
        /// <param name="pageNumber"> </param>
        /// <param name="pageSize">   </param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalPages = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            AddRange(items);
        }

        /// <summary>
        /// 创建分页
        /// </summary>
        /// <param name="sourse">     </param>
        /// <param name="pageNumber"> </param>
        /// <param name="pageSize">   </param>
        /// <returns> </returns>
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> sourse, int pageNumber = 1, int pageSize = 20)
        {
            var count = await sourse.CountAsync();
            var items = await sourse.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}