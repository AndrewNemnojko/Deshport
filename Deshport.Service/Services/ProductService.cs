using Deshport.Domain.EntityModel;
using Deshport.Domain.Response;
using Deshport.Domain.ViewModel.Product;
using Deshport.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deshport.Service.Services
{
    public class ProductService : IProductService
    {
        public Task<BaseResponse<Product>> CreateProduct(ProductView product)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> Delete(ProductView product)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<Product>>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Product>> UpdateProduct(ProductView product)
        {
            throw new NotImplementedException();
        }
    }
}
