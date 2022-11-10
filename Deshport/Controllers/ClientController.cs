using Deshport.Domain.EntityModel;
using Deshport.Domain.ViewModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Deshport.Controllers
{
    public class ClientController : Controller
    { 
        public PartialViewResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Login(LoginView model)
        {
            //Проверка и вариация возвращения
            return PartialView(model);
        }        
        public PartialViewResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Register(RegisterView model)
        {
            //Проверка и вариация возвращения
            return PartialView(model);
        }


        private ClaimsIdentity Authenticate(Client model)
        {
            var claims = new List<Claim>
            {
                new Claim("id", model.Id),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, model.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                "id" , ClaimsIdentity.DefaultRoleClaimType);
        }

    }
}
