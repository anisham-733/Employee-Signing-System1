using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public interface IGuardService
    {
        bool checkLogin(string Username, string Password);
        IEnumerable<EmpQueueDetails> BadgeQueueEmps();
    }
}
