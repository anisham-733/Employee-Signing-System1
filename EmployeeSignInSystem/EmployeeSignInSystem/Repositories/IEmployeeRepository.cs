﻿using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Repositories
{
    public interface IEmployeeRepository
    {
        List<EmployeeDetails> GetEmployeesByName(string FirstName, string LastName);
        List<EmployeeDetails> GetAllEmployees();

        IEnumerable<EmpQueueDetails> GetEmpsToSignOut(string FirstName, string LastName);
        List<EmployeeDetails> FetchDetails(string id);
        int SaveSignInTime(EmployeeTempBadge temp);
        int SaveSignOutTime(string EmployeeId);
        bool checkAlreadyRequested(string id);
        
        
    }
}
