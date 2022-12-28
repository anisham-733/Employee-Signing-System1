using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using EmployeeSignInSystem.Services;
using Moq;
using Xunit;

namespace EmpSigning_Tests.EmployeeRepo
{
    public class EmpRepositoryTests
    {
        private readonly Mock<IEmployeeRepository> _empRepo;
        public EmpRepositoryTests()
        {
            _empRepo= new Mock<IEmployeeRepository>();
        }
        [Fact]
        public void GetEmployeesByName_EmpList()
        {
            //Arrange
            var empList = GetEmployeeDetails();
            _empRepo.Setup(x => x.GetEmployeesByName("Alice", "Mark")).Returns((IEnumerable<EmployeeDetails>)empList[1]);

            //Act
            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);
            IEnumerable<EmployeeDetails> EmpResult = EmpService.GetEmployeesByName("Alice", "Mark");

            //Assert
            Assert.NotNull(EmpResult);
            //Assert.Equal(empList[1].Id, EmpResult.Id);
            //Assert.True(empList[1].Id, EmpResult);

        }
        private List<EmployeeDetails> GetEmployeeDetails()
        {
            List<EmployeeDetails> _employees = new List<EmployeeDetails>
            {
                new EmployeeDetails()
                {
                    Id="104",
                    FirstName="Dia",
                    LastName="Mirza",
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/104pic2.jpeg"
                },
                new EmployeeDetails()
                {
                    Id="309",
                    FirstName="Alice",
                    LastName="Mark",
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/309Passport Size photo Professional.jpg"

                },
                new EmployeeDetails()
                {
                    Id="315",
                    FirstName="Jordan",
                    LastName="Michael",
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/315Passport Size photo Professional.jpg"
                },
                new EmployeeDetails()
                {
                    Id="373",
                    FirstName="Peter",
                    LastName="Parker",
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/373Passport Size photo Professional.jpg"
                }
            };
            return _employees;
        }
    }
}
