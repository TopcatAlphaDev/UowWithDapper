using System;
using System.Data;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks;

namespace UowWithRepository.TestClasses
{
    public class TestClass4 : ITestClass4
    {
        private readonly IShopRepository _shopRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IDbConnection _connection;
        public TestClass4(IDbConnection connection, IShopRepository shopRepository, IInventoryRepository inventoryRepository)
        {
            _shopRepository = shopRepository;
            _inventoryRepository = inventoryRepository;
            _connection = connection;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' using function chaining to add repositories.");

            using var unitOfWork = new UnitOfWork(_connection)
                .With(_shopRepository)
                .With(_inventoryRepository)
                .BeginTransaction();

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