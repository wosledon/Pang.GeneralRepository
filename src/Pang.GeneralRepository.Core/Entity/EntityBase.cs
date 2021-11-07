using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Pang.GeneralRepository.Core.Core;

namespace Pang.GeneralRepository.Core.Entity
{
    /// <summary>
    /// 实体类基类(默认)
    /// </summary>
    public abstract class EntityBase : IEntityBase<Guid>
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        public Guid ModifyUserId { get; set; }

        /// <summary>
        /// 启用标识
        /// </summary>
        public bool EnableMark { get; set; } = true;

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteMark { get; set; } = false;

        /// <summary>
        /// 创建实体
        /// <para> 自动设置一些实体信息,如Id, 创建人Id等 </para>
        /// </summary>
        public virtual void Create()
        {
            Id = Guid.NewGuid();
            var userInfo = LoginUserInfo.Get<EntityBase>();
            CreateUserId = userInfo.Id;
        }

        /// <summary>
        /// 修改实体
        /// <para> 自动设置一些实体信息,如Id, 创建人Id等 </para>
        /// </summary>
        public virtual void Modify()
        {
            var userInfo = LoginUserInfo.Get<EntityBase>();
            ModifyUserId = userInfo.Id;
        }
    }

    /// <summary>
    /// 实体类基类
    /// </summary>
    public abstract partial class EntityBase<T> : IEntityBase<T>
    {
        /// <summary>
        /// Id
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public T CreateUserId { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        public T ModifyUserId { get; set; }

        /// <summary>
        /// 启用标识
        /// </summary>
        public bool EnableMark { get; set; } = true;

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteMark { get; set; } = false;

        /// <summary>
        /// 创建实体
        /// <para> 自动设置一些实体信息,如Id, 创建人Id等 </para>
        /// </summary>
        public abstract void Create();

        /// <summary>
        /// 修改实体
        /// <para> 自动设置一些实体信息,如Id, 创建人Id等 </para>
        /// </summary>
        public abstract void Modify();
    }
}