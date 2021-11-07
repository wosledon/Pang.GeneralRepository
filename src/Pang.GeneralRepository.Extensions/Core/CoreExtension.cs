using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Core.Repository;

namespace Pang.GeneralRepository.Extensions.Core
{
    /// <summary>
    /// 通用仓储核心扩展
    /// </summary>
    public static class CoreExtension
    {
        /// <summary>
        /// 添加通用仓储服务
        /// </summary>
        /// <param name="service"> </param>
        /// <returns> </returns>
        // ReSharper disable once InconsistentNaming
        public static IServiceCollection AddGRC(this IServiceCollection service)
        {
            service.AddSession();
            service.AddGeneralRepository();
            return service;
        }

        /// <summary>
        /// 添加通用仓储核心服务
        /// </summary>
        /// <param name="services"> </param>
        /// <returns> </returns>
        public static IServiceCollection AddGeneralRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            return services;
        }

        /// <summary>
        /// 启用通用仓储中间件
        /// </summary>
        /// <typeparam name="TDbContext"> 数据库上下文 </typeparam>
        /// <param name="app"> </param>
        /// <returns> </returns>
        // ReSharper disable once InconsistentNaming
        public static IApplicationBuilder UseGRCMiddleware<TDbContext>(this IApplicationBuilder app) where TDbContext : DbContext
        {
            var repos = app.ApplicationServices.GetService(typeof(IRepositoryBase<>)) as IRepositoryBase;
            var dbContext = app.ApplicationServices.GetService(typeof(TDbContext)) as TDbContext;

            repos?.Configure(dbContext);

            return app;
        }
    }
}