using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KUSYS_Demo.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using static KUSYS_Demo.Models.AccountViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUSYS_Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly Services.AccountService AccountService_;
        public AccountController(DatabaseContext databaseContext,IConfiguration configuration)
        {
            AccountService_ = new Services.AccountService(databaseContext,configuration);
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                bool controlLoginResult_ = AccountService_.ControlLogin(loginViewModel, HttpContext);
                if (controlLoginResult_)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or password is wrong!");
                }
            }
            return View(loginViewModel);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}

