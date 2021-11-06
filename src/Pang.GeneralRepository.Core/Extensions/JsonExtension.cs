using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pang.GeneralRepository.Core.Extensions
{
    /// <summary>
    /// Json扩展
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 将Json字符串转为对象
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="json"> </param>
        /// <returns> </returns>
        public static T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象转为Json字符串
        /// </summary>
        /// <param name="obj"> </param>
        /// <returns> </returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}