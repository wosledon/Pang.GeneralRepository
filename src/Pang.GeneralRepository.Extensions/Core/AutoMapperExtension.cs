using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Pang.GeneralRepository.Extensions.Core
{
    /// <summary>
    /// 对象映射扩展
    /// </summary>
    public static class AutoMapperExtension
    {
        /// <summary>
        ///
        /// </summary>
        public static IMapper Mapper { get; set; }

        /// <summary>
        /// 配置AutoMapper中间件
        /// </summary>
        /// <param name="mapper"></param>
        public static void Configure(IMapper mapper)
        {
            Mapper = mapper;
        }

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

        /// <summary>
        /// 映射到对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object obj)
        {
            return Mapper.Map<T>(obj);
        }

        /// <summary>
        /// 映射到对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> obj)
        {
            return Mapper.Map<IEnumerable<T>>(obj);
        }
    }
}