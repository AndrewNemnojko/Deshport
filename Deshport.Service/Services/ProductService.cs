using Deshport.DAL.Interfaces;
using Deshport.Domain.EntityModel;
using Deshport.Domain.Response;
using Deshport.Domain.ViewModel.Product;
using Deshport.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Deshport.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> productRepository;
        public ProductService(IBaseRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<BaseResponse<Product>> CreateProduct(ProductView product)
        {
            try
            {
                if(product == null)
                {
                    return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.Error,Description = "NULL!" };
                }
                Product result = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    CreatedDate = DateTime.Now,
                };
                await productRepository.Create(result);
                return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.OK };
            }catch(Exception ex)
            {
                return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.Error, Description = $"[CreateProduct] : {ex.Message}" };
            }
        }

        public async Task<BaseResponse<bool>> Delete(int idproduct)
        {
            try
            {
                var _product = await productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == idproduct);
                if(_product == null)
                {
                    return new BaseResponse<bool> { StatusCode = Domain.Enum.Status.Error, Description = "NULL" };
                }
                await productRepository.Delete(_product);
                return new BaseResponse<bool> { StatusCode = Domain.Enum.Status.OK };
            }catch(Exception ex){
                return new BaseResponse<bool>
                { StatusCode = Domain.Enum.Status.Error, Description = $"[DELETE] : {ex.Message}" };
            }
        }

        public async Task<BaseResponse<Product>> GetProductById(int id)
        {
            try
            {
                var _product = await productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == id);
                if(_product == null)
                {
                    return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.Error, Description = "NULL" };
                }
                return new BaseResponse<Product> {StatusCode= Domain.Enum.Status.OK, Data = _product };
            }catch (Exception ex){
                return new BaseResponse<Product>
                { StatusCode = Domain.Enum.Status.Error, Description = $"[CHANGE] : {ex.Message}" };
            }
        }

        public async Task<BaseResponse<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                var products = await productRepository.GetAll().ToListAsync();
                if (products == null)
                {
                    return new BaseResponse<IEnumerable<Product>> { StatusCode = Domain.Enum.Status.NonFound };
                }                
                return new BaseResponse<IEnumerable<Product>> { StatusCode = Domain.Enum.Status.OK, Data = products };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>> { StatusCode = Domain.Enum.Status.NonFound, Description = $"[GetProducts] : {ex.Message}" };
            }

        }
        public async Task<BaseResponse<Product>> UpdateProduct(Product product)
        {
            try
            {
                var _product = await productRepository.GetAll().FirstOrDefaultAsync(p => p.Id == product.Id);
                if (_product == null)
                {
                    return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.NonFound };
                }
                _product.Price = product.Price;
                _product.Name = product.Name;
                _product.Picture = product.Picture;
                _product.Amount = product.Amount;
                await productRepository.Change(_product);               
                return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.OK, Data = _product };
            }catch(Exception ex)
            {
                return new BaseResponse<Product> { StatusCode = Domain.Enum.Status.Error, Description = $"[GetProducts] : {ex.Message}" };
            }
        }

        
    }
}
