using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace SanEximPortal.Controllers {
    [Authorize(Roles ="admin,user")]
    public class HomeController : Controller {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index() {
            //UserRepository repo = new UserRepository(_configuration);
            //repo.GetUserByUsername("yilmaz@tufan.com");
            return View();
        }
        public IActionResult Error() {
            Models.ErrorModel model = new Models.ErrorModel();
            return View(model);
        }

        public IActionResult Viewer() {
            return View();
        }
        [HttpGet]
        public object GetMenu(DataSourceLoadOptions loadOptions)
        {
            var isAdmin = HttpContext.User.IsInRole("admin");
            var menu = MenuManager.GetMenu(isAdmin);
            return DataSourceLoader.Load(menu, loadOptions);
        }
    }
}