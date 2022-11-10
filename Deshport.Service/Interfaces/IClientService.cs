
using Deshport.Domain.ViewModel.Client;
using System.Security.Claims;

namespace Deshport.Service.Interfaces
{
    public interface IClientService
    {
        Task<ClaimsIdentity> Register(RegisterView model);
        Task<ClaimsIdentity> Login(LoginView model);
    }
}
