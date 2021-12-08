using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Entity;
using System;
using System.Linq;

namespace Pang.GeneralRepository.Core.Extensions
{
    /// <summary>
    /// 核心扩展方法
    /// </summary>
    public static class CoreExtension
    {
        /// <summary>
        /// 批量将实体对象配置到数据库上下文中
        /// </summary>
        /// <param name="modelBuilder"> </param>
        /// <returns> </returns>
        public static ModelBuilder AddEntityTypes(this ModelBuilder modelBuilder)
        {
            var types = typeof(EntityBase).Assembly.GetTypes().AsEnumerable();
            var entityTypes = types.Where(t => !t.IsAbstract && !t.IsInterface && t.IsSubclassOf(typeof(EntityBase)));

            foreach (var type in entityTypes)
            {
                if (modelBuilder.Model.FindEntityType(type) is null)
                {
                    modelBuilder.Model.AddEntityType(type);
                }
            }

            return modelBuilder;
        }

        /// <summary>
        /// 批量将实体对象配置到数据库上下文中
        /// </summary>
        /// <param name="modelBuilder"> </param>
        /// <returns> </returns>
        public static ModelBuilder AddEntityTypes<TEntityBase>(this ModelBuilder modelBuilder)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in assemblies)
            {
                var types = item.GetTypes().AsEnumerable();
                var entityTypes = types.Where(t => !t.IsAbstract && !t.IsInterface && t.IsSubclassOf(typeof(TEntityBase)));

                foreach (var type in entityTypes)
                {
                    if (modelBuilder.Model.FindEntityType(type) is null)
                    {
                        modelBuilder.Model.AddEntityType(type);
                    }
                }
            }

            return modelBuilder;
        }
    }
}