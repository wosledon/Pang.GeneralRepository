using System;
using System.Collections.Generic;
using AutoMapper;
using Pang.GeneralRepository.Web.Entities;

namespace Pang.GeneralRepository.Web.Dtos
{
    [AutoMap(typeof(User))]
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<UserItem> UserItems { get; set; }
    }
}