using System;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks.Interfaces;

namespace UowWithRepository.TestClasses
{
    public class TestClass5Ioc : ITestClass5Ioc
    {
        private readonly IShopGroupRepository _shopGroupRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TestClass5Ioc(IUnitOfWork unitOfWork, IShopGroupRepository shopGroupRepository)
        {
            _shopGroupRepository = shopGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' inject a uow for read.");

            _unitOfWork.With(_shopGroupRepository);

            _shopGroupRepository.GetAll();
        }
    }
}