
using Deshport.DAL.Interfaces;
using Deshport.Domain.EntityModel;

namespace Deshport.DAL.Repositories
{
    public class ProductRepository : IBaseRepository<Product>
    {
        private readonly AppDbContext _DataBase;
        public ProductRepository(AppDbContext dataBase)
        {
            _DataBase = dataBase;
        }
        public async Task Change(Product entity)
        {
            _DataBase.Products.Update(entity);
            await _DataBase.SaveChangesAsync();
        }

        public async Task Create(Product entity)
        {
            await _DataBase.Products.AddAsync(entity);
            await _DataBase.SaveChangesAsync();
        }

        public async Task Delete(Product entity)
        {
            _DataBase.Products.Remove(entity);
            await _DataBase.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _DataBase.Products;
        }
    }
}
