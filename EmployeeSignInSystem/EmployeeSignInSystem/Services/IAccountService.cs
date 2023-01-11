using EmployeeSignInSystem.DTO;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EmployeeSignInSystem.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterGuard(RegisterDTO registerDTO);
        Task SignIn();
        Task<SignInResult> SignInPassword(LoginDTO loginDTO);
        Task SignOut();
    }
}
