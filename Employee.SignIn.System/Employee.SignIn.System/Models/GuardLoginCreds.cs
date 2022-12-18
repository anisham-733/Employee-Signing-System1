using System.ComponentModel.DataAnnotations;

namespace EmployeeSignInSystem.Models
{
    public class GuardLoginCreds
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
