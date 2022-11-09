
using Deshport.DAL.Interfaces;
using Deshport.Domain.EntityModel;

namespace Deshport.DAL.Repositories
{
    public class ClientRepository : IBaseRepository<Client>
    {
        private readonly AppDbContext _DataBase;
        public ClientRepository(AppDbContext dataBase)
        {
            _DataBase = dataBase;
        }

        public async Task Change(Client entity)
        {
            _DataBase.Clients.Update(entity);
            await _DataBase.SaveChangesAsync();
        }

        public async Task Create(Client entity)
        {
            await _DataBase.Clients.AddAsync(entity);
            await _DataBase.SaveChangesAsync();
        }

        public async Task Delete(Client entity)
        {
            _DataBase.Clients.Remove(entity);
            await _DataBase.SaveChangesAsync();
        }

        public IQueryable<Client> GetAll()
        {
            return _DataBase.Clients;
        }
    }
}
