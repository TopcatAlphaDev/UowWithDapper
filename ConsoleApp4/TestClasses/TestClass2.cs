using System;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.TestClasses
{
    public class TestClass2 : ITestClass2
    {
        private readonly IShopRepository _shopRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TestClass2(IShopRepository shopRepository, IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            _shopRepository = shopRepository;
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' inject repositories by function.");

            _unitOfWork.BeginTransaction(_shopRepository, _inventoryRepository);

            try
            {
                _shopRepository.Insert();
                _inventoryRepository.Update();
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.RollBack();
            }
        }
    }
}