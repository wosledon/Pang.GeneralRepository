using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pang.GeneralRepository.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Web.Entities;

namespace Pang.GeneralRepository.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Set()
        {
            var test = new TestEntity()
            {
                Id = 1
            };
            LoginUserInfo.Set(test);

            return Ok(test);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var info = LoginUserInfo.Get<TestEntity>();
            return Ok(info);
        }
    }
}