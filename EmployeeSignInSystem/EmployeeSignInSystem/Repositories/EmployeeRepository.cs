
using EmployeeSignInSystem.DBContext;
using EmployeeSignInSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSignInSystem.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeSigningSystemContext _DbContext;
        public EmployeeRepository(EmployeeSigningSystemContext context)
        {
            _DbContext = context;
        }

        public bool checkAlreadyRequested(string id)
        {
            List<EmployeeTempBadge> checkEmps = _DbContext.EmployeeTempBadge.Where(emp => emp.EmployeeId == id && emp.SignInT.Value.Date == DateTime.Today).ToList();
            if (checkEmps.Count()==0)
            {
                //not in database
                return true;
            }
            return false;
        }

        public List<EmployeeDetails> FetchDetails(string id)
        {
            List<EmployeeDetails> details = _DbContext.EmployeeDetails.Where(emp => emp.Id == id).ToList();
            return details;
        }

        public List<EmployeeDetails> GetAllEmployees()
        {


            var employees = _DbContext.EmployeeDetails.ToList();
            return employees;
        }

        public List<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName)
        {
            List<EmployeeDetails> matchingRecords;
            //if (FirstName==null && LastName==null)
            //{
            //    return new List<EmployeeDetails>();
            //}

            if(!string.IsNullOrEmpty(FirstName))
            {
                return _DbContext.EmployeeDetails.Where(emp => emp.FirstName.Contains(FirstName)).ToList();
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                return _DbContext.EmployeeDetails.Where(emp=>emp.LastName.Contains(LastName)).ToList();

            }
            return new List<EmployeeDetails>();
        }

        public IEnumerable<EmpQueueDetails> GetEmpsToSignOut(string FirstName, string LastName)
        {
            IEnumerable<EmpQueueDetails> records = _DbContext.EmployeeDetails.Join(_DbContext.EmployeeTempBadge,ed=>ed.Id,temp=>temp.EmployeeId,
                (details,temp)=> new EmpQueueDetails
                {
                    FirstName = temp.EmployeeFirstName,
                    LastName = temp.EmployeeLastName,
                    Photo = details.Photo,
                    EmployeeId=temp.EmployeeId,
                    AssignTime = temp.AssignT,
                    TempBadge = temp.TempBadge,
                    SignOutTime = temp.SignOutT,
                }).Where(emp=>emp.FirstName.Contains(FirstName) && emp.LastName.Contains(LastName) && emp.SignOutTime==null && emp.TempBadge!=null)
                .Select(emp=>emp).ToList();

            return records;
                
        }

        public int SaveSignInTime(EmployeeTempBadge temp)
        {
            _DbContext.EmployeeTempBadge.Add(temp);
            return _DbContext.SaveChanges();   
            
        }

        public int SaveSignOutTime(string EmployeeId)
        {
            var InEmps = _DbContext.EmployeeTempBadge.Where(emp => emp.EmployeeId == EmployeeId && emp.AssignT!=null);
            foreach(var x in InEmps)
            {
                x.SignOutT = DateTime.Now;
            }
            return _DbContext.SaveChanges();            
        }

      
    }
}
