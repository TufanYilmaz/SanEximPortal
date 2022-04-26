using DataAccessLayer.Repositories;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SanEximPortal.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        BusinessLayer.Concrete.UserManager userManager;
        public IActionResult Index()
        {
            return View("LoginPage");
        }

        public AuthController(IConfiguration configuration)
        {
            //userManager = new BusinessLayer.Concrete.UserManager(new UserMOCKRepository(configuration));
            userManager = new BusinessLayer.Concrete.UserManager(new UserRepository(configuration));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Auth");
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user, string ReturnUrl)
        {
            var tUser = userManager.GetUserByName(user.Email);

            if (tUser != null)
            {
                if (tUser.Password == user.Password.ToString())
                {
                    var claims = new List<Claim> { 
                        new Claim(ClaimTypes.Name, tUser.Email),
                        new Claim(ClaimTypes.Role, tUser.Role),
                        new Claim(ClaimTypes.SerialNumber, tUser.Id.ToString()),
                    };
                    var claimIdentity = new ClaimsIdentity(claims, "Login");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity));
                    HttpContext.Session.SetString("username", tUser.Email);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["LoginError"] = "Kullanıcı adı ve parola uyuşmazlığı";
                }
            }
            else
            {
                TempData["LoginError"] = "Kullanıcı Bulunamadı";
            }

            return View("LoginPage");
        }
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize,HttpPost]
        public IActionResult SetPassword([FromBody]User user)
        {

            return View();
        }


    }
}
