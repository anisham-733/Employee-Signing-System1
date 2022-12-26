using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        IEnumerable<EmployeeDetails> GetAllEmployees();
        IEnumerable<EmpQueueDetails> GetEmpsToSignOut(string FirstName, string LastName);
        int SaveSignInTime(string id,EmployeeTempBadge temp);
        int SaveSignOutTime(string EmployeeId);


    }
}
