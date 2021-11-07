using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pang.GeneralRepository.Core.Entity;
using Xunit;
using Xunit.Abstractions;

namespace Pang.GeneralRepository.Test.CoreTest
{
    public class CoreExtensionTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CoreExtensionTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in assemblies)
            {
                var types = item.GetTypes();
                var entityTypes = types
                    .Where(t => !t.IsAbstract && !t.IsInterface /*&& t.IsSubclassOf(typeof(EntityBase<>))*/);

                foreach (var type in entityTypes)
                {
                    _testOutputHelper.WriteLine(type.Name);
                }
            }
        }

        [Fact]
        public void Test2()
        {
            var subTypeList = new List<Type>();
            var assembly = typeof(EntityBase<>).Assembly;//获取当前父类所在的程序集``
            var assemblyAllTypes = assembly.GetTypes();//获取该程序集中的所有类型
            foreach (var itemType in assemblyAllTypes)//遍历所有类型进行查找
            {
                var baseType = itemType.BaseType;//获取元素类型的基类
                if (baseType != null)//如果有基类
                {
                    if (baseType.Name == typeof(EntityBase<>).Name)//如果基类就是给定的父类
                    {
                        subTypeList.Add(itemType);//加入子类表中
                    }
                }
                _testOutputHelper.WriteLine(itemType.Name);
            }

            foreach (var type in subTypeList)
            {
                _testOutputHelper.WriteLine(type.Name);
            }
        }
    }

    internal class Father : EntityBase<Guid>
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

    internal class Child1 : EntityBase<Guid>
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

    internal class Child2 : EntityBase<Guid>
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