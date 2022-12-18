using EmployeeSignInSystem.Models;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Repositories
{
    public interface IGuardRepository
    {
        IEnumerable<EmpQueueDetails> BadgeQueueEmps();
    }
}
