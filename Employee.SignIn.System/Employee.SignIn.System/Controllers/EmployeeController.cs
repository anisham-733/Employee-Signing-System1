
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSignIn.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Main()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    var employees=_employeeService.GetAllEmployees();

        //    return View(employees);
        //}
        [HttpGet]
        public IActionResult SignIn(string FirstName = "", string LastName = "")
        {
            //if (string.IsNullOrEmpty(FirstName) & (string.IsNullOrEmpty(LastName)))
            //    {
            //    var employees = _employeeService.GetAllEmployees();

            //    return View(employees);


            //}
            //Empty string in contains always returns true
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            IEnumerable<EmployeeDetails> empRecords = _employeeService.GetEmployeesByName(FirstName, LastName);
            return View(empRecords);
        }

        public IActionResult Details(string Id,EmployeeTempBadge temp)
        {
            //Saving sign In Time for the selected employee
            var a=_employeeService.SaveSignInTime(Id, temp);
            if (a != 0)
            {
                //Fetching employees who are in queue to receive badges
                IEnumerable<EmpQueueDetails> inQueueEmps = _employeeService.BadgeQueueEmps();

            }
            return View("BadgeQueue");

        }
        public IActionResult SignOut()
        {
            return View();
        }
    }
}
