using Deshport.DAL.Interfaces;
using Deshport.Domain.EntityModel;
using Deshport.Domain.Response;
using Deshport.Domain.ViewModel.Client;
using Deshport.Service.Interfaces;
using System.Security.Claims;


namespace Deshport.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> clientRepos;
        public ClientService(IBaseRepository<Client> clientRepos)
        {
            this.clientRepos = clientRepos;
        }

        public Task<IBaseResponse<ClaimsIdentity>> Login(LoginView model)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<ClaimsIdentity>> Register(RegisterView model)
        {
            throw new NotImplementedException();
        }
    }
}
