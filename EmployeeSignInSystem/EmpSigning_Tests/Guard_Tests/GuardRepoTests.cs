using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmpSigning_Tests.Guard_Tests
{
    public class GuardRepoTests
    {
        private readonly Mock<IGuardRepository> _guardRepo;
        public GuardRepoTests()
        {
            _guardRepo= new Mock<IGuardRepository>();
        }

        [Fact]
       
        public void SaveAssignTime_Save()
        {
            //arrange
            List<EmployeeTempBadge> employeeTempBadges= GetTempBadgeDetails();
            _guardRepo.Setup(x => x.SaveAssignTime(employeeTempBadges[0].TempBadge, employeeTempBadges[0].EmployeeId)).Returns(1);
                
            var GuardService = new EmployeeSignInSystem.Services.GuardService(_guardRepo.Object);

            //act
            var result = GuardService.SaveAssignTime(employeeTempBadges[0].TempBadge, employeeTempBadges[0].EmployeeId);

            Assert.Equal(1, result);
            Assert.True(1 == result);


        }
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
