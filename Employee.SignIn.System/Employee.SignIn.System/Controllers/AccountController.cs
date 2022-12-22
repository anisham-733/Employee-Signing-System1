using EmployeeSignInSystem.DTO;
using EmployeeSignInSystem.Models.IdentityEntities;
using EmployeeSignInSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSignInSystem.Controllers
{
    public class AccountController : Controller
    {
             
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            //check for validation errors
            if (ModelState.IsValid == false)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
                return View(registerDTO);

            }

            IdentityResult identityResult = await _service.RegisterGuard(registerDTO);
            //IdentityResult contains status of Database operation
            if (identityResult.Succeeded)
            {
                //creating identity cookie and sending it to server as req
                await _service.SignIn();
                return RedirectToAction("GetBadgeQueue", "Guard");

            }
            else
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("GetBadgeQueue", error.Description);
                }
                return View(registerDTO);
            }
        }

    }
}
