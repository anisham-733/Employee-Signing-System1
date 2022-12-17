using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeService(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public IEnumerable<EmployeeDetails> GetAllEmployees()
        {
            return _empRepo.GetAllEmployees();
        }

        public IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName)
        {
            return _empRepo.GetEmployeesByName(FirstName, LastName);

        }
    }
}
