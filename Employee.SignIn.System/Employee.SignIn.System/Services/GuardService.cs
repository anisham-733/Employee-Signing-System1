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

        public bool checkLogin(string Username, string Password)
        {
            if(Username=="Anisha" && Password == "hello123")
            {
                return true;

            }
            return false;
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

        public IEnumerable<EmployeeTempBadge> GetReport(DateTime Sdate = new DateTime(), DateTime Edate = new DateTime(), string FirstName="", string LastName="")
        {
           return _guardRepo.GetReport(Sdate, Edate, FirstName, LastName);


        }
    }
}
