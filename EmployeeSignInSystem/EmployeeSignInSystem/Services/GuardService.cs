using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using System;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Services
{
    public class GuardService : IGuardService
    {
        private readonly IGuardRepository _guardRepo;
        public GuardService(IGuardRepository guardRepo)
        {
            _guardRepo = guardRepo;
        }       
        public IEnumerable<EmpQueueDetails> BadgeQueueEmps()
        {
            return _guardRepo.BadgeQueueEmps();
        }

        public int SaveAssignTime(string TempBadge, string Id)
        {
            return _guardRepo.SaveAssignTime(TempBadge, Id);
        }

        public IEnumerable<EmpQueueDetails> BadgeOutEmps()
        {
            return _guardRepo.BadgeOutEmps();
        }

        public IEnumerable<EmployeeTempBadge> GetReport(DateTime Sdate, DateTime Edate, string FirstName="", string LastName="")
        {
            return _guardRepo.GetReport1(Sdate, Edate, FirstName, LastName);    
        }
    }
}
