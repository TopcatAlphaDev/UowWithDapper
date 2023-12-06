using System;
using System.Linq;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.TestClasses
{
    public class TestClass7 : ITestClass7
    {
        private readonly IShopUnitOfWork _shopUnitOfWork;
        public TestClass7(IShopUnitOfWork shopUnitOfWork)
        {
            _shopUnitOfWork = shopUnitOfWork;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' inject specific unitOfWork for read.");

            Console.WriteLine($" Count : {_shopUnitOfWork.ShopGroupRepository.GetCount()}");
            Console.WriteLine($" List : {string.Join(", ", _shopUnitOfWork.ShopGroupRepository.GetAll().ToList().Select(x =>$"{x.Number} - {x.Name}")) }");
        }
    }
}