using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSignInSystem.Models
{
    public class EmpQueueDetails
    {
        [Key]
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public DateTime? AssignTime { get; set; }
        public DateTime? SignOutTime { get; set; } 
        public string TempBadge { get; internal set; }
    }
}
