using Deshport.DAL.Interfaces;
using Deshport.Domain.EntityModel;
using Deshport.Domain.Helpers;
using Deshport.Domain.Response;
using Deshport.Domain.ViewModel.Client;
using Deshport.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Deshport.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<Client> clientRepos;
        public AuthService(IBaseRepository<Client> clientRepos)
        {
            this.clientRepos = clientRepos;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginView model)
        {
            try
            {
                var client = await clientRepos.GetAll().FirstOrDefaultAsync(p => p.Mail == model.Mail);
                if(client == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        StatusCode = Domain.Enum.Status.NonFound,
                        Description = "Not registered",
                    };
                }if(client.Password != Hashing.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        StatusCode = Domain.Enum.Status.Error,
                        Description = "Password or login is not correct",
                    };
                }
                var result = Authenticate(client);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = Domain.Enum.Status.OK,
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = $"[LOGIN] : {ex.Message}",
                    StatusCode = Domain.Enum.Status.Error
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterView model)
        {
            try
            {
                var client = await clientRepos.GetAll().FirstOrDefaultAsync(p => p.Mail == model.Mail);
                if(client != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Such user already exists",
                        StatusCode = Domain.Enum.Status.Error,
                    };
                }
                client = new Client()
                {                   
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mail = model.Mail,
                    Password = Hashing.HashPassword(model.Password),
                    Role = Domain.Enum.Roles.User,
                    DateRegistration = DateTime.Now
                };
                await clientRepos.Create(client);
                var result = Authenticate(client);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Successful registration",
                    StatusCode = Domain.Enum.Status.OK,
                };
            }catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = $"[REGISTRATION] : {ex.Message}",
                    StatusCode = Domain.Enum.Status.Error
                };
            }
        }


        private ClaimsIdentity Authenticate(Client client)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, client.Mail),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, client.Role.ToString()),               
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
