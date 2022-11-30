using Deshport.Domain.EntityModel;
using Deshport.Domain.ViewModel.Product;
using Deshport.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Deshport.Controllers
{
    public class ProductController : Controller        
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment _webHostEnvironment)
        {
            this.productService = productService;
            this._webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index() => View();
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(ProductView viewProduct)
        {         
            if (ModelState.IsValid)
            {
                if(viewProduct.Imagefile == null)
                {
                    viewProduct.Picture = "/resources/default-image.png";
                }
                else
                {
                    string folder = "resources/simpleprod/";
                    folder += Guid.NewGuid().ToString() + "_" + viewProduct.Imagefile.FileName;
                    viewProduct.Picture = folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await viewProduct.Imagefile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }
                var product = await productService.CreateProduct(viewProduct); 
                if (product.StatusCode == Domain.Enum.Status.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(viewProduct);
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
        public async Task<IActionResult> ChangeProduct(ProductView product)
        {
            if (product.Imagefile == null)
            {
                product.Picture = "/resources/default-image.png";
            }
            else
            {
                string folder = "resources/simpleprod/";
                folder += Guid.NewGuid().ToString() + "_" + product.Imagefile.FileName;
                product.Picture = folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await product.Imagefile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
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
