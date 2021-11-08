using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pang.GeneralRepository.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Core.Helper;
using Pang.GeneralRepository.Core.Repository;
using Pang.GeneralRepository.Extensions.Core;
using Pang.GeneralRepository.Extensions.RepositoryExtensions;
using Pang.GeneralRepository.Web.Data;
using Pang.GeneralRepository.Web.Dtos;
using Pang.GeneralRepository.Web.Entities;
using AutoMapper;

namespace Pang.GeneralRepository.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryBase<User, SimpleDbContext> _userRepositoryBase;

        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                              IRepositoryBase<User, SimpleDbContext> userRepositoryBase,
                              IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
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
        public ActionResult SetLoginInfo()
        {
            var test = new TestEntityBase()
            {
                Id = 1
            };
            LoginUserInfo.Set(test);

            return Ok(test);
        }

        [HttpGet]
        public ActionResult GetLoginInfo()
        {
            var info = LoginUserInfo.Get<TestEntityBase>();
            return Ok(info);
        }

        [HttpGet]
        public async Task<ActionResult> CreateUser()
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

            var res = await _userRepositoryBase.FindAsync(x => x.Id.Equals(user.Id));
            return Ok(new
            {
                Result = res,
                Data = user
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var res = await _userRepositoryBase.FindPagedListAsync(x => true, 1, 4);

            //var data = await PagedList<User>.CreateAsync(_userRepositoryBase.Queryable.Include(x => x.UserItems), 1, 4);

            var data = await _userRepositoryBase.Include(x=>x.UserItems).FindPagedListAsync(1, 4);

            var result = data.MapTo<UserDto>();
            return Ok(new
            {
                Result = result,
            });
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var res = await _userRepositoryBase
                .FindAsync(
                    x => x.Id.Equals(Guid.Parse("257e5f42-1787-4242-82c7-780f09248824")),
                    t => t.UserItems);

            return Ok(new
            {
                Result = res,
            });
        }

        [HttpGet]
        public ActionResult Map()
        {
            var data = new TestUser2()
            {
                Id = Guid.NewGuid(),
                FirstName = "张三",
                LastName = "1"
            };

            var Result = data.MapTo<UserDto>();

            var data2 = new TestUser2()
            {
                Id = Guid.NewGuid(),
                FirstName = "李四",
                LastName = "2"
            };

            var Result2 = data2.MapTo<UserDto>();

            return Ok(new{
                Result1 = Result,
                Result2 = Result2
            });
        }
    }
}