using EmployeeSignInSystem.DTO;
using EmployeeSignInSystem.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace EmployeeSignInSystem.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationUser _user;
        public AccountRepository(UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            _userManager = userManager;
            _user = user;
        }

        public IdentityResult RegisterGuard(RegisterDTO registerDTO)
        {
            throw new System.NotImplementedException();
        }

        //public IdentityResult RegisterGuard(RegisterDTO registerDTO)
        //{
        //    _user.Email=registerDTO.Email;
        //    _user.PhoneNumber=registerDTO.PhoneNumber;
        //    _user.UserName = registerDTO.Username;




        //}
    }
}
