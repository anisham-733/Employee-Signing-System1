using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using EmployeeSignIn.Controllers;
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using EmployeeSignInSystem.Services;
using Moq;
using Xamarin.Forms;
using Xunit;

namespace EmpSigning_Tests.EmployeeRepo
{
    public class EmpRepositoryTests
    {
        private readonly Mock<IEmployeeRepository> _empRepo;
        public EmpRepositoryTests()
        {
            _empRepo = new Mock<IEmployeeRepository>();
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
        public void GetEmployeesByName_ArgumentNullException()
        {
            //Arrange
            List<EmployeeDetails> empList = GetEmployeeDetails();
            //Expected
            List<EmployeeDetails> expectedResult = new List<EmployeeDetails>();
            _empRepo.Setup(x => x.GetEmployeesByName(empList[2].FirstName, empList[2].LastName)).Returns(expectedResult);

            //Act
            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);
            List<EmployeeDetails> result = EmpService.GetEmployeesByName(null, null);

            Assert.Equal(expectedResult.Count(), result.Count());

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
            Assert.Equal(GetEmployeeDetails().Count(), result.Count());
            Assert.Equal(GetEmployeeDetails().ToString(), result.ToString());
            Assert.True(empList.Equals(empList));
        }
        [Fact]

        public void SaveSignOutTime_Product()
        {
            List<EmployeeTempBadge> empList = GetTempBadgeDetails();
            _empRepo.Setup(x => x.SaveSignOutTime("104")).Returns(1);

            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);

            //act
            var result = EmpService.SaveSignOutTime("104");

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result);
            Assert.True(1 == result);

        }

        [Fact]
        public void checkAlreadyRequested_Save()
        {
            //arrange
            List<EmployeeTempBadge> empList = GetTempBadgeDetails();
            List<EmployeeDetails> employeeDetails = GetEmployeeDetails();
            _empRepo.Setup(x => x.checkAlreadyRequested(empList[1].EmployeeId)).Returns(true);
            _empRepo.Setup(x => x.FetchDetails(employeeDetails[1].Id)).Returns(employeeDetails);
            _empRepo.Setup(x => x.SaveSignInTime(empList[1])).Returns(1);
            //true means not in database
            //act
           // EmployeeTempBadge temp = new EmployeeTempBadge();
            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);
            var result = EmpService.SaveSignInTime(empList[1].EmployeeId, empList[1]);

            Assert.NotNull(result);
            Assert.Equal(1, result);
            Assert.True(1 == result);
        }


        [Fact]
        public void checkAlreadyRequested_SameDayRequest()
        {
            //arrange
            List<EmployeeTempBadge> empList = GetTempBadgeDetails();
            List<EmployeeDetails> employeeDetails = GetEmployeeDetails();
            _empRepo.Setup(x => x.checkAlreadyRequested(empList[1].EmployeeId)).Returns(false);
            
            //false means  in database
            //act
 
            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);
            var result = EmpService.SaveSignInTime(empList[1].EmployeeId, empList[1]);

            Assert.NotNull(result);
            Assert.Equal(0, result);
            Assert.True(0 == result);
        }
        [Fact]
        public void SaveSignOutTime_IdIsNull()
        {
            List<EmployeeTempBadge> empList = GetTempBadgeDetails();
            _empRepo.Setup(x => x.SaveSignOutTime(empList[0].EmployeeId)).Returns(0);

            var EmpService = new EmployeeSignInSystem.Services.EmployeeService(_empRepo.Object);

            //act
            var result = EmpService.SaveSignOutTime(null);

            //assert
            Assert.NotNull(result);
            Assert.Equal(0, result);
            Assert.True(0 == result);

        }

        private List<EmployeeDetails> GetEmployeeDetails()
        {
            List<EmployeeDetails> _employees = new List<EmployeeDetails>
            {
                new EmployeeDetails()
                {
                    Id=null,
                    FirstName="Dia",
                    LastName="Mirza",
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/309Passport Size photo Professional.jpg"
                },
                new EmployeeDetails()
                {
                    Id="387",
                    FirstName="Christine",
                    LastName="Hass",
                    Photo="https://sanidhyastorage.blob.core.windows.net/jamesbond/Employees/309Passport Size photo Professional.jpg"

                },
                new EmployeeDetails()
                {
                    Id="315",
                    FirstName=null,
                    LastName=null,
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
        [Fact]
        private List<EmployeeTempBadge> GetTempBadgeDetails()
        {
            List<EmployeeTempBadge> employeeTempBadges = new List<EmployeeTempBadge>
            {
                new EmployeeTempBadge()
                {
                    EmployeeId = "104",
                    EmployeeFirstName = "Dia",
                    EmployeeLastName = "Mirza",
                    TempBadge = "abdc",
                    SignInT = new DateTime(2022,12,28,13,30,46,531),
                    SignOutT = new DateTime(2022,12,28, 13,31,35,437),
                    AssignT = new DateTime(2022 ,12, 28, 13,32,39,972),
                    Id = 29

                },
                new EmployeeTempBadge()
                {
                     EmployeeId = "387",
                    EmployeeFirstName = "Christine",
                    EmployeeLastName = "Hass",
                    TempBadge = "abjdnHBH7",
                    SignInT = new DateTime(  2022 , 12 , 29, 12,01,39,183),
                    SignOutT = null,
                    AssignT = new DateTime(2022 , 12 , 29, 12,02,04,945),
                    Id = 88

                },
                new EmployeeTempBadge()
                {
                     EmployeeId =  "692",
                    EmployeeFirstName = "Sania",
                    EmployeeLastName = "Arora",
                    TempBadge = "GCHJG43X",
                    SignInT = new DateTime(2022,12,28,13,30,57,243),
                    SignOutT = new DateTime(2022 , 12 , 28, 13,32,34,795),
                    AssignT = new DateTime(2022 , 12 , 28, 13,32,13,281),
                    Id = 256

                },
                new EmployeeTempBadge()
                {


                }
            };
            return employeeTempBadges;
        }
}
}







    //   NULL     12:02:04.9450776 88
    //692 Sania   Arora       2022-12-28 13:30:57.2434002 2022-12-28 13:32:34.7951841 2022-12-28 13:32:13.2817007 256
    //373 Peter   Parker  34ghbGBB    2022-12-28 13:30:54.8011686 2022-12-28 13:32:46.7825737 2022-12-28 13:32:08.7414153 562
    //309 Alice   Mark    hbjkn   2022-12-28 13:30:49.4153337 2022-12-28 13:32:43.8347691 2022-12-28 13:31:48.1725707 761



