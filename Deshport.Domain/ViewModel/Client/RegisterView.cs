
using System.ComponentModel.DataAnnotations;


namespace Deshport.Domain.ViewModel.Client
{
    public class RegisterView
    {
        [Required(ErrorMessage = "Enter your name")]
        [MaxLength(15, ErrorMessage = "The name must be no more than 15 characters long")]
        [MinLength(3, ErrorMessage = "The name must not be less than 3 characters long")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Enter last name")]
        [MaxLength(25, ErrorMessage = "Last name must be no more than 25 characters long")]
        [MinLength(4, ErrorMessage = "Last name must not be less than 4 characters long")]
        public string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter your email address!")]
        public string Mail { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Password must contain more than 6 characters")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
