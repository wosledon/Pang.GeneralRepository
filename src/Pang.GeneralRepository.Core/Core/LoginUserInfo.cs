using Microsoft.AspNetCore.Http;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Core.Extensions;

namespace Pang.GeneralRepository.Core.Core
{
    /// <summary>
    /// 登录信息(默认)
    /// </summary>
    public static class LoginUserInfo
    {
        private static IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// </summary>
        /// <param name="httpContextAccessor"> </param>
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取身份信息
        /// </summary>
        /// <returns> </returns>
        public static T Get<T>()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("UserInfo").ToObject<T>();
        }

        /// <summary>
        /// 设置身份信息
        /// </summary>
        /// <param name="userInfo"> </param>
        public static void Set(EntityBase userInfo)
        {
            _httpContextAccessor.HttpContext.Session.SetString("UserInfo", userInfo.ToJson());
        }

        /// <summary>
        /// 设置身份信息
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="userInfo"> </param>
        public static void Set<T>(EntityBase<T> userInfo)
        {
            _httpContextAccessor.HttpContext.Session.SetString("UserInfo", userInfo.ToJson());
        }
    }
}