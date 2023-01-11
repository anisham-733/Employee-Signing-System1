using EmployeeSignInSystem.DTO;
using Microsoft.AspNetCore.Identity;

namespace EmployeeSignInSystem.Repositories
{
    public interface IAccountRepository
    {
        IdentityResult RegisterGuard(RegisterDTO registerDTO);
    }
}
