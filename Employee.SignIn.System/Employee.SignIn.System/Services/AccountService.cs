using EmployeeSignInSystem.DTO;
using EmployeeSignInSystem.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeSignInSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationUser _user;
        public AccountService(UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            _userManager = userManager;
            _user = user;
        }
        public async Task<IdentityResult> RegisterGuard(RegisterDTO registerDTO)
        {
            _user.Email = registerDTO.Email;
            _user.PhoneNumber = registerDTO.PhoneNumber;
            _user.UserName = registerDTO.Username;
            return await _userManager.CreateAsync(_user,registerDTO.Password);
        }

        
    }
}
