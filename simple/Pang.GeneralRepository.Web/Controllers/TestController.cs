using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Pang.GeneralRepository.Extensions;

namespace Pang.GeneralRepository.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Success("成功");
        }

        [NonAction]
        public virtual SuccessObjectResult Success([ActionResultObjectValue] object value)
        {
            return new SuccessObjectResult(value);
        }
    }

    /// <summary>
    /// </summary>
    public class SuccessObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status200OK;

        /// <summary>
        /// </summary>
        /// <param name="value"> </param>
        public SuccessObjectResult(object value) : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}