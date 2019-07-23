using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SimpleTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleTodo.Controllers {
    public class AccountController : Controller {
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser login)
        {
            var db = new SimpleTodoDbContext();
            var user = db.Users
                .Where(u => u.LoginName == login.Name && u.Password == login.Password)
                .FirstOrDefault();
            if (user != null) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.LoginName)
                    
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                //return Redirect("/Lists");
                return Redirect("/Lists/Start"); //old prj not nav bar
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
