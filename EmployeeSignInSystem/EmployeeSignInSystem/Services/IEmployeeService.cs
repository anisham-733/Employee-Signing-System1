using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        List<EmployeeDetails> GetAllEmployees();
        IEnumerable<EmpQueueDetails> GetEmpsToSignOut(string FirstName, string LastName);
        int SaveSignInTime(string id,EmployeeTempBadge temp);
        int SaveSignOutTime(string EmployeeId);


    }
}
