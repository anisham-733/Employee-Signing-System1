using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        IEnumerable<EmployeeDetails> GetAllEmployees();
    }
}
