using Azure.Messaging;
using EmployeeSignInSystem.Models;
using EmployeeSignInSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using Xceed.Wpf.Toolkit;

namespace EmployeeSignInSystem.Controllers
{
    public class GuardController : Controller
    {
        private readonly IGuardService _guardService;
        public GuardController(IGuardService guardService)
        {
            _guardService = guardService;
        }      

        public IActionResult GetBadgeQueue()
        {
            ViewBag.TempBadgeStatus = TempData["TempBadgeStatus"];
            //Fetching employees who are in queue to receive badges
            IEnumerable<EmpQueueDetails> inQueueEmps = _guardService.BadgeQueueEmps();
            return View(inQueueEmps);
        }
        public IActionResult AssignBadge(string TempBadge,string id)
        {
            var saved=_guardService.SaveAssignTime(TempBadge,id);
            if (saved == 1)
            {
                
                TempData["TempBadgeStatus"] = "Temporary Badge is assigned";
                return RedirectToAction("GetBadgeQueue");
            }
            TempData["TempBadgeStatus"] = "This Temporary badge number has already been assigned to other employee";
            return RedirectToAction("GetBadgeQueue");
        }

        public IActionResult GetAssignedBadges() 
        {
            IEnumerable<EmpQueueDetails> empsWithTempBadges=_guardService.BadgeOutEmps();
            return View(empsWithTempBadges);
        
        }

        public IActionResult GetReport(DateTime StartDate, DateTime EndDate , string FirstName = "", string LastName = "")
        {
            ViewBag.FirstName=FirstName; ViewBag.LastName=LastName;
            ViewBag.StartDate=StartDate; ViewBag.EndDate=EndDate;
            IEnumerable<EmployeeTempBadge> emps = _guardService.GetReport(StartDate, EndDate, FirstName, LastName);

            return View(emps);

        }
       
    }
}
