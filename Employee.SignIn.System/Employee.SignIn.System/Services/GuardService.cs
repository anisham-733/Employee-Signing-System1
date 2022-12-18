using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Repositories;
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

        public bool checkLogin(string Username, string Password)
        {
            if(Username=="Anisha" && Password == "hello123")
            {
                return true;

            }
            return false;
        }
        public IEnumerable<EmpQueueDetails> BadgeQueueEmps()
        {
            return _guardRepo.BadgeQueueEmps();
        }
    }
}
