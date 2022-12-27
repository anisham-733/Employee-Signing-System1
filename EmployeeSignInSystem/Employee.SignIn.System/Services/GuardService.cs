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
            DateTime Stemp = new DateTime(0001,01,01,00,00,00);
            DateTime Etemp = new DateTime(0001, 01, 01, 00, 00, 00);
            DateTime newtemp = new DateTime(2050, 01, 01, 00, 00, 00);

            //if names given
            if (!string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName)) 
            {
                //if dates given
                if(Sdate!=Stemp || Edate != Etemp)
                {
                    //all 4 valid
                    return _guardRepo.GetReport(Sdate,Edate,FirstName,LastName);
                }
                //when only names
                return _guardRepo.GetReport(Stemp,newtemp, FirstName="", LastName="");

            }
            //names not given
            else 
            { 
                if (Sdate != Stemp || Edate != Etemp)
                {
                    //dates given
                    return _guardRepo.GetReportByTimePeriod(Sdate,Edate);

                }
                //dates not given
                return _guardRepo.GetReportByTimePeriod(Stemp, newtemp);


            }



            

        }
    }
}
