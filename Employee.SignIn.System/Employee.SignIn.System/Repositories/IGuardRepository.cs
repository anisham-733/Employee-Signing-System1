using EmployeeSignInSystem.Models;
using System;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Repositories
{
    public interface IGuardRepository
    {
        IEnumerable<EmpQueueDetails> BadgeQueueEmps();
        int SaveAssignTime(string TempBadge,string Id);
        IEnumerable<EmpQueueDetails> BadgeOutEmps();
        IEnumerable<EmployeeTempBadge> GetReport(DateTime SDate=default, DateTime EDate=default,string FirstName="", string LastName="");
        IEnumerable<EmployeeTempBadge> GetReportByTimePeriod(DateTime Sdate, DateTime EDate);
    }
}
