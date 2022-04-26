using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SanEximPortal.Controllers
{

    [Route("api/[controller]")]
    public class AgencyApiController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly AgencyManager _agencyManager;
        public AgencyApiController(IConfiguration configuration)
        {
            _configuration = configuration;
            //_agencyManager = new AgencyManager(new AgencyRepository(configuration));
            _agencyManager = new AgencyManager(new AgencyMOCKRepository(configuration));
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return _agencyManager.GetAll();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Post(string values)
        {
            var newUser = new Agency();
            JsonConvert.PopulateObject(values, newUser);

            if (!TryValidateModel(newUser))
                return BadRequest("Model Hatalı !!");

            _agencyManager.AddOrUpdate(newUser);

            return Ok();
        }

        [HttpPut]
        public ActionResult Put(int key, string values)
        {
            var user = _agencyManager.Get(key);
            JsonConvert.PopulateObject(values, user, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver() { NamingStrategy = null },
            });
            if (ModelState.IsValid)
            {

            }
            //if (!TryValidateModel(user))
            //    return BadRequest("Model Hatalı");
            user.Id = key;
            _agencyManager.AddOrUpdate(user);

            return Ok();
        }
    }
}