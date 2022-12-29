using EmployeeSignInSystem.DBContext;
using EmployeeSignInSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeSignInSystem.Repositories
{
    public class GuardRepository:IGuardRepository
    {
        private readonly EmployeeSigningSystemContext _DBContext;
        private  DateTime Sdate = new DateTime(0001, 01, 01, 00, 00, 00);
        private  DateTime newtemp = new  DateTime(2050, 01, 01, 00, 00, 00);
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

              
        public IEnumerable<EmployeeTempBadge> GetReportByTimePeriod(DateTime? Sdate = null , DateTime? EDate =null)
        {
            var Edate1 = EDate;

            if(EDate == DateTime.MinValue)
            {
                Edate1 = DateTime.MaxValue; 
            }
            //And condition to implement is signout time
            var getByTime = _DBContext.EmployeeTempBadge.Where(emp => (emp.SignInT >= Sdate) && emp.SignInT<Edate1 && (emp.SignOutT < Edate1 || emp.SignOutT==null) && emp.AssignT!=null).ToList();
            return getByTime;
        }

        public IEnumerable<EmployeeTempBadge> GetReport1(DateTime Sdate, DateTime Edate, string FirstName, string LastName)
        {
            IQueryable<EmployeeTempBadge> query = _DBContext.EmployeeTempBadge.Where(emp => emp.Id != null && emp.AssignT!=null);

            if (!string.IsNullOrEmpty(FirstName))
            {
                query = query.Where(emp => emp.EmployeeFirstName.Contains(FirstName));
            }
            if(!string.IsNullOrEmpty(LastName))
            {
                query = query.Where(emp => emp.EmployeeLastName.Contains(LastName));
            }
            if (Sdate != DateTime.MinValue || Sdate==DateTime.MinValue)
            {
                query = query.Where(emp => emp.SignInT >= Sdate);
            }
            if(Edate!= DateTime.MinValue)
            {
                query = query.Where(emp => emp.SignOutT <= Edate);
            }
            if (Edate == DateTime.MinValue)
            {
                Edate = DateTime.MaxValue;
                query = query.Where(emp => emp.SignOutT <= Edate || emp.SignOutT==null);
            }


            return query.ToList();
        }

        public IEnumerable<EmployeeTempBadge> GetReport(DateTime SDate = default, DateTime EDate = default, string FirstName = "", string LastName = "")
        {
            throw new NotImplementedException();
        }
    }
    }

