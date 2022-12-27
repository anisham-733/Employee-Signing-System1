using EmployeeSignInSystem.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EmpSigning_Tests.EmployeeRepo;

namespace EmpSigning_Tests.EmployeeService
{
    public  class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeService> _employeeService;
        public EmployeeServiceTests()
        {
            _employeeService = new  Mock<IEmployeeService>();
        }

        [Fact]
        public void GetAllEmployees()
        {
            //Arrange
            
            




        }

        
    }
}
