using EmployeeSignInSystem.DBContext;
using EmployeeSignInSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSignInSystem.Repositories
{
    public class GuardRepository:IGuardRepository
    {
        private readonly EmployeeSigningSystemContext _DBContext;
        public GuardRepository(EmployeeSigningSystemContext dbContext)
        {
            _DBContext = dbContext;
        }

        public int SaveAssignTime(string TempBadge, string Id)
        {
            var alreadyExistingBadge = _DBContext.EmployeeTempBadge.Where(emp => emp.TempBadge==TempBadge);
            if (alreadyExistingBadge.Count() == 0)
            {
                //not in database
                var badgeOutEmps = _DBContext.EmployeeTempBadge.Where(emp=>emp.EmployeeId==Id);
                foreach (var x in badgeOutEmps)
                {
                    x.TempBadge = TempBadge;
                    x.AssignT = System.DateTime.Now;
                }
                return _DBContext.SaveChanges();

            }
            return 0;
            
            ;          

            
        }

        public IEnumerable<EmpQueueDetails> BadgeQueueEmps()
        {
            var inQueueEmps = _DBContext.EmployeeTempBadge.
                Join(_DBContext.EmployeeDetails, tempBadge => tempBadge.EmployeeId, empDetails => empDetails.Id,
                (tempBadge, empDetails) => new EmpQueueDetails
                {
                    EmployeeId = empDetails.Id,
                    FirstName = empDetails.FirstName,
                    LastName = empDetails.LastName,
                    Photo = empDetails.Photo,
                    AssignTime = tempBadge.AssignT,
                    TempBadge=tempBadge.TempBadge,

                }).Where(emp => emp.AssignTime == null).Select(emp => emp);

            return inQueueEmps;
        }

        public IEnumerable<EmpQueueDetails> BadgeOutEmps()
        {
            var inQueueEmps = _DBContext.EmployeeTempBadge.
                Join(_DBContext.EmployeeDetails, tempBadge => tempBadge.EmployeeId, empDetails => empDetails.Id,
                (tempBadge, empDetails) => new EmpQueueDetails
                {
                    EmployeeId = empDetails.Id,
                    FirstName = empDetails.FirstName,
                    LastName = empDetails.LastName,
                    Photo = empDetails.Photo,
                    AssignTime = tempBadge.AssignT,
                    TempBadge = tempBadge.TempBadge,
                    SignOutTime=tempBadge.SignOutT

                }).Where(emp => emp.SignOutTime == null && emp.AssignTime!=null).Select(emp => emp);

            return inQueueEmps;
        }

        public IEnumerable<EmployeeTempBadge> GetReport(DateTime SDate = default, DateTime EDate = default, string FirstName = "", string LastName = "")
        {
            //for all 4 && condition
            return _DBContext.EmployeeTempBadge.Where(emp => emp.EmployeeFirstName.Contains(FirstName) && emp.EmployeeLastName.Contains(LastName) && emp.SignInT>SDate && emp.SignOutT<EDate).ToList();
        }

        public IEnumerable<EmployeeTempBadge> GetReportByTimePeriod(DateTime Sdate, DateTime EDate)
        {
            //And condition to implement is signout time
            var getByTime = _DBContext.EmployeeTempBadge.Where(emp => emp.SignInT > Sdate && emp.SignInT<EDate && (emp.SignOutT < EDate || emp.SignOutT==null)).ToList();
            return getByTime;
        }
    }
}
