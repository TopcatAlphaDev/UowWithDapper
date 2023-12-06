using System;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.TestClasses
{
    public class TestClass3 : ITestClass3
    {
        private readonly IShopRepository _shopRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly Func<IRepository[], IUnitOfWork> _getUnitOfWork;
        public TestClass3(IShopRepository shopRepository, IInventoryRepository inventoryRepository, 
            Func<IRepository[], IUnitOfWork> getUnitOfWork)
        {
            _shopRepository = shopRepository;
            _inventoryRepository = inventoryRepository;
            _getUnitOfWork = getUnitOfWork;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' using Ioc function to determine repositories in Uow constructor.");

            using var unitOfWork = _getUnitOfWork(new IRepository[] { _shopRepository, _inventoryRepository} );

            unitOfWork.BeginTransaction();
            try
            {
                _shopRepository.Insert();
                _inventoryRepository.Update();
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.RollBack();
            }
        }
    }
}