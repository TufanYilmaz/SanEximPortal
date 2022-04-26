using DataAccessLayer.Repositories;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SanEximPortal.Controllers
{
    [Route("api/[controller]")]
    public class UserGridController : Controller
    {
        BusinessLayer.Concrete.UserManager userManager;

        public UserGridController(IConfiguration configuration)
        {
            //userManager = new BusinessLayer.Concrete.UserManager(new UserMOCKRepository(configuration));
            userManager = new BusinessLayer.Concrete.UserManager(new UserRepository(configuration));
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return userManager.GetAll();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Post(string values)
        {
            var newUser = new User();
            JsonConvert.PopulateObject(values, newUser);

            if (!TryValidateModel(newUser))
                return BadRequest("Model Hatalı !!");

            userManager.AddOrUpdate(newUser);

            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int key,string values)
        {
            var user = userManager.Get(key);
            JsonConvert.PopulateObject(values, user,new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver() { NamingStrategy = null },
            });
            if (ModelState.IsValid)
            {

            }
            //if (!TryValidateModel(user))
            //    return BadRequest("Model Hatalı");
            user.Id = key;
            userManager.AddOrUpdate(user);

            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            userManager.Delete(key);
        }
    }
}
