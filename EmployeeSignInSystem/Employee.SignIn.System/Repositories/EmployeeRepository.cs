
using EmployeeSignInSystem.DBContext;
using EmployeeSignInSystem.Models;
using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<EmployeeTempBadge> checkEmps = _DbContext.EmployeeTempBadge.Where(emp => emp.EmployeeId == id && emp.SignInT.Value.Date == System.DateTime.Today).ToList();
            if (checkEmps.Count()==0)
            {
                //not in database
                return true;
            }
            return false;
        }

        public IEnumerable<EmployeeDetails> FetchDetails(string id)
        {
            IEnumerable<EmployeeDetails> details = _DbContext.EmployeeDetails.Where(emp => emp.Id == id).ToList();
            return details;
        }

        public IEnumerable<EmployeeDetails> GetAllEmployees()
        {


            var employees = _DbContext.EmployeeDetails.ToList();
            return employees;
        }

        public IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName)
        {

            IEnumerable<EmployeeDetails> matchingRecords = _DbContext.EmployeeDetails.
                Where(emp => emp.FirstName.Contains(FirstName) || emp.LastName.Contains(LastName)).ToList();

            return matchingRecords;
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
            var InEmps = _DbContext.EmployeeTempBadge.Where(emp => emp.EmployeeId == EmployeeId);
            foreach(var x in InEmps)
            {
                x.SignOutT = System.DateTime.Now;
            }
            return _DbContext.SaveChanges();            
        }

      
    }
}
