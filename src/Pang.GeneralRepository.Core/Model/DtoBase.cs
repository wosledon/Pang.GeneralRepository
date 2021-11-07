using System;

namespace Pang.GeneralRepository.Core.Model
{
    /// <summary>
    /// 模型基类
    /// </summary>
    public class DtoBase : IDtoBase<Guid>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
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
        public bool EnableMark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteMark { get; set; }
    }
}