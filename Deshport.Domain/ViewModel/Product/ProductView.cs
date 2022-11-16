
using System.ComponentModel.DataAnnotations;

namespace Deshport.Domain.ViewModel.Product
{
    public class ProductView
    {
        [Required(ErrorMessage = "Enter product name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Enter product price")]
        public int Price { get; set; }       
    }
}
