using System;

namespace Pang.GeneralRepository.Core.Model
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class ReturnDto
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public Object Data { get; set; }
    }
}