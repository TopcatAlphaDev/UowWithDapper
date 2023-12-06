using System;
using System.Data;
using UowWithRepository.Repositories.Interfaces;
using UowWithRepository.TestClasses.Interfaces;
using UowWithRepository.UnitOfWorks;

namespace UowWithRepository.TestClasses
{
    public class TestClass5 : ITestClass5
    {
        private readonly IShopGroupRepository _shopGroupRepository;
        private readonly IDbConnection _connection;
        public TestClass5(IDbConnection connection, IShopGroupRepository shopGroupRepository)
        {
            _shopGroupRepository = shopGroupRepository;
            _connection = connection;
        }

        public void Do()
        {
            Console.WriteLine($"Do '{GetType().Name}' created a uow for read.");

            using var unitOfWork = new UnitOfWork(_connection)
                .With(_shopGroupRepository);

            _shopGroupRepository.GetAll();
        }
    }
}