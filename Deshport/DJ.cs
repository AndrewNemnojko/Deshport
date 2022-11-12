using Deshport.DAL.Interfaces;
using Deshport.DAL.Repositories;
using Deshport.Domain.EntityModel;
using Deshport.Service.Interfaces;
using Deshport.Service.Services;

namespace Deshport
{
    public static class DJ
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Client>, ClientRepository>();
            services.AddScoped<IBaseRepository<Product>, ProductRepository>();
        }
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();            
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
