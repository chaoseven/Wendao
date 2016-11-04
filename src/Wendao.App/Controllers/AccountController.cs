using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wendao.App.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Authentication;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Wendao.App.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Signin(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(LoginViewModel loginInfo, string returnUrl)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, loginInfo.Email, ClaimValueTypes.String));
            var ident = new ClaimsIdentity(claims, "Passport");
            var princ = new ClaimsPrincipal(ident);
            await HttpContext.Authentication.SignInAsync("Cookie", princ,new AuthenticationProperties { IsPersistent = loginInfo.RememberMe });
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return Redirect("/Home/Index");
        }
    }
}
