using Deshport.Domain.ViewModel.Client;
using Deshport.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Deshport.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService clientService;
        public AuthController(IAuthService clientService)
        {
            this.clientService = clientService;
        }
        public PartialViewResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                var response = await clientService.Login(model);
                if(response.StatusCode == Domain.Enum.Status.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Main");
                }
                ModelState.AddModelError("",response.Description); 
            }
            return PartialView(model);
        }        
        public PartialViewResult Register()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                var response = await clientService.Register(model);
                if (response.StatusCode == Domain.Enum.Status.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                    return RedirectToAction("Index", "Main");
                }
                ModelState.AddModelError("", response.Description); 
            }
            return PartialView(model);
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Main");
        }

    }
}
