using EmployeeSignInSystem.Models;
using System;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public interface IGuardService
    {
        bool checkLogin(string Username, string Password);
        IEnumerable<EmpQueueDetails> BadgeQueueEmps();
        int SaveAssignTime(string TempBadge, string Id);
        IEnumerable<EmpQueueDetails> BadgeOutEmps();
        IEnumerable<EmployeeTempBadge> GetReport(DateTime Sdate = new DateTime(), DateTime Edate = new DateTime(), string FirstName = "", string LastName = "");
    }
}
