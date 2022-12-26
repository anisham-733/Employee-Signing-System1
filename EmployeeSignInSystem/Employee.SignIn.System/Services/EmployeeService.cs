using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSignInSystem.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeService(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        public int SaveSignInTime(string id,EmployeeTempBadge temp)
        {
            if (_empRepo.checkAlreadyRequested(id))
            {
                IEnumerable<EmployeeDetails> details = _empRepo.FetchDetails(id);
                Random r = new Random();
                int tempId = r.Next(1, 1000);
                temp.Id = tempId;
                temp.EmployeeId = id;
                temp.EmployeeFirstName = details.First().FirstName;
                temp.EmployeeLastName = details.First().LastName;
                temp.SignInT = System.DateTime.Now;
                temp.AssignT = null;
                temp.SignOutT = null;
                temp.TempBadge = null;
                return _empRepo.SaveSignInTime(temp);
            }
            return 0;
            
        }

        public IEnumerable<EmployeeDetails> GetAllEmployees()
        {
            return _empRepo.GetAllEmployees();
        }

        public IEnumerable<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName)
        {
            return _empRepo.GetEmployeesByName(FirstName, LastName);

        }

        public IEnumerable<EmpQueueDetails> GetEmpsToSignOut(string FirstName, string LastName)
        {
            return _empRepo.GetEmpsToSignOut(FirstName, LastName);
        }

        public int SaveSignOutTime(string EmployeeId)
        {
            return _empRepo.SaveSignOutTime(EmployeeId);
        }
    }
}
