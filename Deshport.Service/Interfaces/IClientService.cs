﻿
using Deshport.Domain.Response;
using Deshport.Domain.ViewModel.Client;
using System.Security.Claims;

namespace Deshport.Service.Interfaces
{
    public interface IClientService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterView model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginView model);
    }
}
