using EmployeeSignInSystem.DataDB;
using EmployeeSignInSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSignInSystem.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeSigningSystemContext _DbContext;
        public EmployeeRepository(EmployeeSigningSystemContext context)
        {
            _DbContext = context;
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
    }
}
