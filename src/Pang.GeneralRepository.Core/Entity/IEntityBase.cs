using System.ComponentModel.DataAnnotations;

namespace Pang.GeneralRepository.Core.Entity
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public partial interface IEntityBase<T>
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required]
        public T Id { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [Required]
        public T CreateUserId { get; set; }

        /// <summary>
        /// 修改人Id
        /// </summary>
        [Required]
        public T ModifyUserId { get; set; }

        /// <summary>
        /// 启用标识
        /// </summary>
        public bool EnableMark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteMark { get; set; }

        /// <summary>
        /// 创建实体
        /// <para> 自动设置一些实体信息,如Id, 创建人Id等 </para>
        /// </summary>
        public void Create();

        /// <summary>
        /// 修改实体
        /// <para> 自动设置一些实体信息,如Id, 创建人Id等 </para>
        /// </summary>
        public void Modify();
    }
}