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
using Pang.GeneralRepository.Core.Repository;
using Pang.GeneralRepository.Web.Data;
using Pang.GeneralRepository.Web.Entities;

namespace Pang.GeneralRepository.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryBase<User, SimpleDbContext> _userRepositoryBase;

        public HomeController(ILogger<HomeController> logger,
            IRepositoryBase<User, SimpleDbContext> userRepositoryBase)
        {
            _logger = logger;
            _userRepositoryBase = userRepositoryBase ?? throw new ArgumentNullException(nameof(userRepositoryBase));
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
            var test = new TestEntityBase()
            {
                Id = 1
            };
            LoginUserInfo.Set(test);

            return Ok(test);
        }

        [HttpGet]
        public ActionResult Get()
        {
            var info = LoginUserInfo.Get<TestEntityBase>();
            return Ok(info);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var user = new User()
            {
                UserItems = new List<UserItem>()
                {
                    new UserItem(){Name = "1"},
                    new UserItem(){Name = "2"},
                    new UserItem(){Name = "3"},
                    new UserItem(){Name = "4"},
                }
            };
            user.Create();

            await _userRepositoryBase.InsertAsync(user);
            await _userRepositoryBase.SaveChangesAsync();

            var res = _userRepositoryBase.FindAsync(x => x.Id.Equals(user.Id));
            return Ok(new
            {
                Result = res,
                Data = user
            });
        }
    }
}