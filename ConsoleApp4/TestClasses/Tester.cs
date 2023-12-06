using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using UowWithRepository.TestClasses.Interfaces;

namespace UowWithRepository.TestClasses
{
    public class Tester
    {
        private readonly ITestClass1 _testClass1;
        private readonly ITestClass2 _testClass2;
        private readonly ITestClass3 _testClass3;
        private readonly ITestClass4 _testClass4;
        private readonly ITestClass4Iso _testClass4Iso;
        private readonly ITestClass5 _testClass5;
        private readonly ITestClass5Ioc _testClass5Ioc;
        private readonly ITestClass6 _testClass6;
        private readonly ITestClass7 _testClass7;

        public Tester(IContainer container)
        {
            _testClass1 = container.Resolve<ITestClass1>();
            _testClass2 = container.Resolve<ITestClass2>();
            _testClass3 = container.Resolve<ITestClass3>();
            _testClass4 = container.Resolve<ITestClass4>();
            _testClass4Iso = container.Resolve<ITestClass4Iso>();
            _testClass5 = container.Resolve<ITestClass5>();
            _testClass5Ioc = container.Resolve<ITestClass5Ioc>();
            _testClass6 = container.Resolve<ITestClass6>();
            _testClass7 = container.Resolve<ITestClass7>();
        }
        public void Do()
        {
            _testClass1.Do();
            _testClass2.Do();
            _testClass3.Do();
            _testClass4.Do();
            _testClass4Iso.Do();
            _testClass5.Do();
            _testClass5Ioc.Do();
            _testClass6.Do();
            _testClass7.Do();

            Console.WriteLine("");
            Console.WriteLine(" *** second run to test ioc behavior *** ");
            Console.WriteLine("");

            _testClass1.Do();
            _testClass2.Do();
            _testClass3.Do();
            _testClass4.Do();
            _testClass4Iso.Do();
            _testClass5.Do();
            _testClass5Ioc.Do();
            _testClass6.Do();
            _testClass7.Do();

            Console.WriteLine("");
            Console.WriteLine(" *** third run to test parallel behavior *** ");
            Console.WriteLine("");

            var testClasses = new List<ITestClass>() { _testClass1, _testClass2, _testClass3, _testClass4, _testClass4Iso, _testClass5, _testClass5Ioc, _testClass6, _testClass7 };
            Parallel.ForEach(testClasses, testClass => testClass.Do());
        }
    }
}
