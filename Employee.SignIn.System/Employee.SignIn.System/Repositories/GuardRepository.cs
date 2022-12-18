using EmployeeSignInSystem.DBContext;
using EmployeeSignInSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    }
}
