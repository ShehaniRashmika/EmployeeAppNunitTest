using System;
using System.Runtime.CompilerServices;
using EmployeeApp.Repository;
using EmployeeApp.Services;
using Moq;
using NUnit;
using NUnit.Framework;


namespace UnitTestsProject
{
    [TestFixture]
    public class Tests
    {
        private IEmployeeService _service;
        private Mock<ITaxservice> _mockTaxService;
        private Mock<IEmployeeRepository> _mockRepository;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IEmployeeRepository>(MockBehavior.Strict);
            _mockTaxService= new Mock<ITaxservice>(MockBehavior.Strict);
            _service= new EmployeeService( _mockTaxService.Object, _mockRepository.Object );
           
        }

        [Test]
        public void TestCalculateTax()
        {
            //Arrange
            _mockRepository.Setup(r => r.Get(It.IsAny<int>()))
                .Returns(new Employee
            {
                Name = "John Smith",
                Id = 1,
                JoiningDate = DateTime.Parse("1/1/2018"),
                Salary = 5000
            });

            _mockTaxService.Setup(t => t.GetTaxRate()).Returns(0.10);

            //Act
            var actual = _service.CalculateTax(1, DateTime.Parse("4/30/2018"));
            var expected = 2000.0;

            Assert.AreEqual(expected, actual);
        }
    }
}