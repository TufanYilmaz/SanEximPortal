using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SanEximPortal.Controllers
{
    [Authorize(Roles ="admin")]
    public class UsersController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager _usertManager;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
            //_usertManager = new UserManager(new UserMOCKRepository(configuration));
            _usertManager = new UserManager(new UserRepository(configuration));
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
