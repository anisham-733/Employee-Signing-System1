using System.ComponentModel.DataAnnotations;

namespace EmployeeSignInSystem.DTO
{
    
    public class RegisterDTO
    {
        
        [Required(ErrorMessage ="UserName can't be blank")]
        public string Username { get; set; }

        [Key]

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be in proper format")]

        
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number can't be blank")]
        [RegularExpression("^[0-9]*$",ErrorMessage="Phone number should contain numbers only")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and confirm password do not match")]
        public string ConfirmPassword   { get; set; }
    }
}
