using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using EmployeeSignIn.Controllers;
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
            List<EmployeeDetails> empList = GetEmployeeDetails();
            //IEnumerable<EmployeeDetails> employeeDetails = empList;
            _empRepo.Setup(x => x.GetEmployeesByName("Alice", "Mark")).Returns(empList);

            //Act
            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);
           List<EmployeeDetails> EmpResult = EmpService.GetEmployeesByName("Alice", "Mark");

            //  Controller
                        
            //Assert
            Assert.NotNull(EmpResult);
            Assert.Equal(empList[1].Id, EmpResult[1].Id);
            Assert.True(empList[1].Id == EmpResult[1].Id);

        }
        [Fact]

        public void GetAllEmployees_Emps()
        {
            //arrange
            var empList = GetEmployeeDetails();
            _empRepo.Setup(x => x.GetAllEmployees()).Returns(empList);

            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);

            //act
            var result = EmpService.GetAllEmployees();

            //assert
            Assert.NotNull(result);
            Assert.Equal(GetEmployeeDetails().Count(),result.Count());
            Assert.Equal(GetEmployeeDetails().ToString(),result.ToString());
            Assert.True(empList.Equals(empList));
        }
        [Fact]

        public void SaveSignOutTime_Product()
        {
            var empList = GetEmployeeDetails();
            _empRepo.Setup(x => x.SaveSignOutTime("104")).Returns(1);

            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);

            //act
            var result = EmpService.SaveSignOutTime("104");

            //assert
            Assert.NotNull(result);
            Assert.Equal(1,result );
            Assert.True(1 == result);

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
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/309Passport Size photo Professional.jpg"
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
