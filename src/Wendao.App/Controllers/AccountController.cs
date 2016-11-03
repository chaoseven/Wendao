using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wendao.App.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Wendao.App.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Signin(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Signin(LoginViewModel loginInfo,string returnUrl)
        {
            return Redirect(returnUrl);
        }
    }
}
