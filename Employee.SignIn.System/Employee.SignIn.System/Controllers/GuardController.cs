using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace EmployeeSignInSystem.Controllers
{
    public class GuardController : Controller
    {
        private readonly IGuardService _guardService;
        public GuardController(IGuardService guardService)
        {
            _guardService = guardService;
        }

        [HttpGet]
        public IActionResult Login(string Username, string Password)
        {
            if(_guardService.checkLogin(Username, Password))
            {
                return RedirectToAction("GetBadgeQueue");
                
                
            }



            return View();
        }

        public IActionResult GetBadgeQueue()
        {
            //Fetching employees who are in queue to receive badges
            IEnumerable<EmpQueueDetails> inQueueEmps = _guardService.BadgeQueueEmps();
            return View(inQueueEmps);
        }
        public IActionResult AssignBadge(string TempBadge,string id)
        {
            
            
            return RedirectToAction("GetBadgeQueue");
        }
    }
}
