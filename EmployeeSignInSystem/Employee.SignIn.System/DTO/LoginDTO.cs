using System.ComponentModel.DataAnnotations;

namespace EmployeeSignInSystem.DTO
{
    public class LoginDTO
    {
        [Key]
        [Required(ErrorMessage ="Username can't be blank")]
        
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
