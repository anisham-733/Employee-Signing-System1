using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeSignInSystem.Models
{
    public partial class EmployeeTempBadge
    {
        public string Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string TempBadge { get; set; }
        public DateTime SignInT { get; set; }
        public DateTime? SignOutT { get; set; }
        public DateTime? AssignT { get; set; }
    }
}
