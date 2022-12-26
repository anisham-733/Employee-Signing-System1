using EmployeeSignInSystem.DTO;
using EmployeeSignInSystem.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeSignInSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        private readonly ApplicationUser _user;
        public AccountService(UserManager<ApplicationUser> userManager, ApplicationUser user,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _user = user;
        }
        public async Task<IdentityResult> RegisterGuard(RegisterDTO registerDTO)
        {
            _user.Email = registerDTO.Email;
            _user.PhoneNumber = registerDTO.PhoneNumber;
            _user.UserName = registerDTO.Username;
            return await _userManager.CreateAsync(_user,registerDTO.Password);
        }

        public async Task SignIn()
        {
            //storing cookie in browser
            await _signInManager.SignInAsync(_user, isPersistent: false);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> SignInPassword(LoginDTO loginDTO)
        {
            //after 3 invalid login checks, lockout the account for user
            return await _signInManager.PasswordSignInAsync(loginDTO.Username, loginDTO.Password, isPersistent: false,lockoutOnFailure:false);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
