
using System.ComponentModel.DataAnnotations;


namespace Deshport.Domain.ViewModel.Client
{
    public class RegisterView
    {
        [Required(ErrorMessage = "Введите имя")]
        [MaxLength(15, ErrorMessage = "Имя должн быть длиной не более 15ти символов")]
        [MinLength(4, ErrorMessage = "Имя не должно быть длиной менее 4ех символов")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Введите фамилию")]
        [MaxLength(25, ErrorMessage = "Фамилия должна быть длиной не более 25ти символов")]
        [MinLength(4, ErrorMessage = "Фамилия не должна быть длиной менее 4ех символов")]
        public string LastName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты!")]
        public string Mail { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать более 6ти символов")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
