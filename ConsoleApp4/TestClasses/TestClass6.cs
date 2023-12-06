using System;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.TestClasses
{
    public class TestClass6 : ITestClass6
    {
        private readonly IInventoryUnitOfWork _inventoryUnitOfWork;
        public TestClass6(IInventoryUnitOfWork inventoryUnitOfWork)
        {
            _inventoryUnitOfWork = inventoryUnitOfWork;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' inject specific unitOfWork with transaction.");

            _inventoryUnitOfWork.BeginTransaction();

            try
            {
                _inventoryUnitOfWork.ShopRepository.Insert();
                _inventoryUnitOfWork.InventoryRepository.Update();
                _inventoryUnitOfWork.Commit();
            }
            catch
            {
                _inventoryUnitOfWork.RollBack();
            }
        }
    }
}