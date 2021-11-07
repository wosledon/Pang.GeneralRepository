namespace Pang.GeneralRepository.Core.Model
{
    /// <summary>
    /// 模型基类接口
    /// </summary>
    /// <typeparam name="T"> 主键类型 </typeparam>
    public interface IDtoBase<T>
    {
        /// <summary>
        /// 主键Id
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
        public bool EnableMark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool DeleteMark { get; set; }
    }
}