
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Windows;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit;
using Microsoft.AspNetCore.Http;

namespace EmployeeSignIn.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

             
        [HttpGet]
        public IActionResult SignIn(string FirstName = "", string LastName = "")
        {
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            
            ViewBag.RequestStatus = TempData["RequestStatus"];
            ViewBag.SignOutEmp = TempData["SignOutEmp"];
            List<EmployeeDetails> empRecords = _employeeService.GetEmployeesByName(FirstName, LastName);
            return View(empRecords);
        }
        [HttpGet]
        public IActionResult GetBadgeQueue(string Id,EmployeeTempBadge temp)
        {

            //Saving sign In Time for the selected employee
            var a=_employeeService.SaveSignInTime(Id, temp);
            
            if (a != 0)
            {
                TempData["RequestStatus"] = "Your Request for Temporary Badge has been sent";
                return RedirectToAction("SignIn");
            }
            TempData["RequestStatus"] = "You have already sent your Request for Temporary Badge today. It's in queue";
            return RedirectToAction("SignIn");
            

        }
        
        public IActionResult SignOut(string FirstName="",string LastName="")
        {
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            IEnumerable<EmpQueueDetails> emps = _employeeService.GetEmpsToSignOut(FirstName, LastName);

            return View(emps);
        }

        [HttpGet]
        public IActionResult SignEmpOut(string EmployeeId)
        {
            //Saving sign In Time for the selected employee
            var a = _employeeService.SaveSignOutTime(EmployeeId);

            if (a != 0)
            {
                TempData["SignOutEmp"] = "Successfully signed out";
                return RedirectToAction("SignIn");
            }
            TempData["SignOutEmp"] = "Error occurred";
            return RedirectToAction("SignIn");
        }
    }
}
