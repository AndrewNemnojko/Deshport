
using System.ComponentModel.DataAnnotations;


namespace Deshport.Domain.ViewModel.Client
{
    public class LoginView
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты!")]
        public string Mail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать более 6ти символов")]
        public string Password { get; set; }
        
    }
}
