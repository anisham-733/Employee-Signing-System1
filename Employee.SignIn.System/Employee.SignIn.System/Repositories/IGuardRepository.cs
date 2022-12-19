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
        IEnumerable<EmployeeTempBadge> GetReport(DateTime SDate=new DateTime(), DateTime EDate=new DateTime(),string FirstName="", string LastName="");
    }
}
