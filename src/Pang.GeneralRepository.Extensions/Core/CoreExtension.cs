using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pang.GeneralRepository.Core.Core;
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
        /// </summary>
        /// <typeparam name="TDbContext"> </typeparam>
        /// <param name="services"> </param>
        /// <returns> </returns>
        public static IServiceCollection AddGeneralRepository<TDbContext>(this IServiceCollection services) where TDbContext : GRCDbContext
        {
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
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
            //var dbContext = app.ApplicationServices.GetService(typeof(TDbContext)) as GRCDbContext;

            using (var scope = app.ApplicationServices.CreateScope())
            {
                try
                {
                    var repos = app.ApplicationServices.GetService(typeof(RepositoryBase<>));
                    var dbContext = scope.ServiceProvider.GetService<TDbContext>() as GRCDbContext;

                    var methodInfo = typeof(RepositoryBase<>).GetMethod("Configure");
                    methodInfo?.Invoke(repos, new[] { dbContext });
                    //repos.Configure(dbContext);
                }
                catch (Exception e)
                {
                    Console.WriteLine("GRC中间件一场");
                }
            }

            return app;
        }
    }
}