using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        IEnumerable<EmployeeDetails> GetAllEmployees();

        IEnumerable<EmpQueueDetails> GetEmpsToSignOut(string FirstName, string LastName);
        IEnumerable<EmployeeDetails> FetchDetails(string id);
        int SaveSignInTime(EmployeeTempBadge temp);
        int SaveSignOutTime(string EmployeeId);
        bool checkAlreadyRequested(string id);
        
        
    }
}
