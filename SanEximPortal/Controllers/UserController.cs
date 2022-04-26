using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SanEximPortal.ViewModels;
using System;
using System.Linq;

namespace SanEximPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager _userManager;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            //_userManager = new UserManager(new UserMOCKRepository(configuration));
            _userManager = new UserManager(new UserRepository(configuration));
        }
        public IActionResult ChangePassword()
        {
            var claim = HttpContext.User.Claims.First(x => x.Type == System.Security.Claims.ClaimTypes.SerialNumber);
            var user = _userManager.Get(Convert.ToInt32( claim.Value));

            var viewModel = new UserPasswordChangeViewModel();
            //viewModel = (UserPasswordChangeViewModel)user;
            var values=JsonConvert.SerializeObject(user, Helpers.JsonHelper.jsonSerializerSettings);
            JsonConvert.PopulateObject(values, viewModel);
            //var viewModel = user as UserPasswordChangeViewModel;

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserPasswordChangeViewModel userInfo)
        {
            ModelState["Role"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                _userManager.ChangePassword(userInfo.Id, userInfo.ChangedPassword);
                return View("ChangePasswordSuccess");
            }

            return View(userInfo);
        }
    }
}
