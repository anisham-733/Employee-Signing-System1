using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        IEnumerable<EmployeeDetails> GetAllEmployees();
        IEnumerable<EmployeeDetails> FetchDetails(string id);
        int SaveSignInTime(EmployeeTempBadge temp);
        bool checkAlreadyRequested(string id);
        
        
    }
}
