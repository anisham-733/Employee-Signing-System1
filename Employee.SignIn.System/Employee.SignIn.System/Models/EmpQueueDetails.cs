using Microsoft.VisualBasic;
using System;

namespace EmployeeSignInSystem.Models
{
    public class EmpQueueDetails
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public DateTime? AssignTime { get; set; }
                   
    }
}
