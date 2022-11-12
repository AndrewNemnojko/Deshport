
using System.ComponentModel.DataAnnotations;


namespace Deshport.Domain.ViewModel.Client
{
    public class LoginView
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Enter your email address!")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter password")]
        [MinLength(6, ErrorMessage = "Password must contain more than 6 characters")]
        public string Password { get; set; }
        
    }
}
