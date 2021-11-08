using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using AutoMapper;
using Pang.GeneralRepository.Core.Entity;
using Pang.GeneralRepository.Web.Dtos;
using AutoMapper.Configuration.Annotations;

namespace Pang.GeneralRepository.Web.Entities
{
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

    public class TestUser: EntityBase
    {
        public string Name{get; set;}
    }

    public class TestUser2: EntityBase
    {
        public string FirstName{get; set;}

        public string LastName{get; set;}
    }
}