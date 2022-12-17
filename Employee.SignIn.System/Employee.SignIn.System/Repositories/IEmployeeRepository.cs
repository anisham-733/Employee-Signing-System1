using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        IEnumerable<EmployeeDetails> GetAllEmployees();
    }
}
