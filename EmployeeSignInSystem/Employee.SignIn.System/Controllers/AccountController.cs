using EmployeeSignInSystem.DTO;
using EmployeeSignInSystem.Models.IdentityEntities;
using EmployeeSignInSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;

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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
                return View(loginDTO);
            }

            //else sign in using email and password
            var result = await _service.SignInPassword(loginDTO);
            if (result.Succeeded)
            {
                TempData["LoginStatus"] = "Login successfull";
                return RedirectToAction("GetBadgeQueue", "Guard");
            }
            TempData["LoginStatus"] = "Login not successfull!!. Invalid username or password";
            ModelState.AddModelError("Login", "Invalid username or password");
            return View(loginDTO);
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

        public async Task<IActionResult> Logout()
        {
            await _service.SignOut();
            
            return RedirectToAction("Login", "Account");
        }

    }
}
