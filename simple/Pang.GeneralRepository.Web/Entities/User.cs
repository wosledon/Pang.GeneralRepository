using System;
using System.Collections.Generic;
using Pang.GeneralRepository.Core.Entity;

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
}