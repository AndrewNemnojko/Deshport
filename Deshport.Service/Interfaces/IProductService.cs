using Deshport.Domain.EntityModel;
using Deshport.Domain.Response;
using Deshport.Domain.ViewModel.Product;

namespace Deshport.Service.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<Product>> CreateProduct(ProductView product);
        Task<BaseResponse<Product>> UpdateProduct(ProductView product);
        Task<BaseResponse<bool>> Delete (ProductView product);
        Task<BaseResponse<IEnumerable<Product>>> GetProducts();
    }
}
