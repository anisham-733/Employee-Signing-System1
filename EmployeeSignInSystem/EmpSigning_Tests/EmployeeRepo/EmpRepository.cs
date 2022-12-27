using System;
using System.Collections.Generic;
using System.Text;
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using EmployeeSignInSystem.Services;
using Moq;

namespace EmpSigning_Tests.EmployeeRepo
{
    public class EmpRepository
    {
        private readonly Mock<IEmployeeRepository> _empRepo;
        public EmpRepository()
        {
            _empRepo= new Mock<IEmployeeRepository>();
        }

        public void GetAllEmployees_EmpList()
        {
            var empList = GetEmployeeDetails();
            _empRepo.Setup(x=>x.GetAllEmployees()).Returns(empList);

            //var EmpService = new EmployeeService(_empRepo.Object);
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
