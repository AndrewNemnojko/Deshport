
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Deshport.Domain.ViewModel.Product
{
    public class ProductView
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Enter product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter product price")]
        public int Price { get; set; }
        public int Amount { get; set; }
        public IFormFile? Imagefile { get; set; }
        public string? Picture { get; set; }
    }
}
