using System;
using System.Data;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks;

namespace UowWithRepository.TestClasses
{
    public class TestClass1 : ITestClass1
    {
        private readonly IShopRepository _shopRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IDbConnection _connection;
        public TestClass1(IDbConnection connection, IShopRepository shopRepository, IInventoryRepository inventoryRepository)
        {
            _shopRepository = shopRepository;
            _inventoryRepository = inventoryRepository;
            _connection = connection;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' inject repositories by constructor.");

            using var unitOfWork = new UnitOfWork(_connection, _shopRepository, _inventoryRepository);

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