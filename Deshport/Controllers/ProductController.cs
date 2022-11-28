using Deshport.Domain.EntityModel;
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
        public IActionResult Index() => View();
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(ProductView viewProduct)
        {
            if (ModelState.IsValid)
            {
                var product = await productService.CreateProduct(viewProduct);
                if(product.StatusCode == Domain.Enum.Status.OK)
                {
                    return View("ListProduct");   
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<PartialViewResult> ListProduct() 
        { 
            var products = await productService.GetProducts();
            return PartialView("ListProduct", products.Data.ToList());
        }       
        public async Task<IActionResult> ChangeProduct(int id)
        {
            var product = await productService.GetProductById(id);
            if(product.StatusCode == Domain.Enum.Status.OK)
            {
                return View(product.Data);
            }          
            return View(id);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeProduct(Product product)
        {
            var _product = await productService.UpdateProduct(product);
            if (_product.StatusCode == Domain.Enum.Status.OK)
            {
                return RedirectToAction("Index");
                
            }
            return View(_product.Data);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await productService.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
