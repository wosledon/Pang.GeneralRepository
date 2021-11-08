using System;
using System.Collections.Generic;
using AutoMapper;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Web.Dtos;

namespace Pang.GeneralRepository.Web.Entities
{
    [AutoMap(typeof(UserDto))]
    public class User : EntityBase
    {
        public ICollection<UserItem> UserItems { get; set; }

        public override void Create()
        {
            Id = Guid.NewGuid();
            CreateUserId = Guid.NewGuid();
        }

        public override void Modify()
        {
            ModifyUserId = Guid.NewGuid();
        }
    }
}