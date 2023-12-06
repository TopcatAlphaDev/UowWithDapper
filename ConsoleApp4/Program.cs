using System;
using UowWithRepository.UnitOfWorks;
using UowWithRepository.ProgramLogic;
using UowWithRepository.TestClasses;

namespace UowWithRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            new Tester(Ioc.Configure()).Do();
            Console.ReadLine();
        }
    }
}
