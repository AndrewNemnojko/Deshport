using Deshport.Domain.ViewModel.Product;
using Deshport.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Deshport.Controllers
{
    public class ProductController : Controller        
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(ProductView viewProduct)
        {
            if (ModelState.IsValid)
            {
                var product = await productService.CreateProduct(viewProduct);
                if(product.StatusCode == Domain.Enum.Status.OK)
                {
                    return RedirectToAction("Index", "Main");   
                }
            }
            return View(viewProduct);
        }
    }
}
