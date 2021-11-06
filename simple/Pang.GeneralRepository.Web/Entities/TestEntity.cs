using System;
using Pang.GeneralRepository.Core.Core;
using Pang.GeneralRepository.Core.Entity;

namespace Pang.GeneralRepository.Web.Entities
{
    public class TestEntity : EntityBase<int>
    {
        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Modify()
        {
            throw new NotImplementedException();
        }
    }
}