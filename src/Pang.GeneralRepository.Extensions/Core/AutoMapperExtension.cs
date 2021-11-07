using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Pang.GeneralRepository.Extensions.Core
{
    /// <summary>
    /// 对象映射扩展
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        /// 添加AutoMapper
        /// <para> 在实体类以及模型中使用Attribute: [AutoMap(typeof(Model))] </para>
        /// <example> [AutoMap(typeof(UserDto))] class User{} </example>
        /// </summary>
        /// <param name="service"> </param>
        /// <returns> </returns>
        public static IServiceCollection AddAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(config =>
            {
                config.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            });
            return service;
        }
    }
}