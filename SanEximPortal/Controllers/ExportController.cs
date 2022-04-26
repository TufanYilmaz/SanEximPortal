using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SanEximPortal.Models;
using SanEximPortal.ViewModels;
using System;

namespace SanEximPortal.Controllers
{

    public class ExportController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ExportManager _exportManager;
        public ExportController(IConfiguration configuration)
        {
            _configuration = configuration;
            //_exportManager = new ExportManager(new ExportMOCKRepository(configuration));
            _exportManager = new ExportManager(new ExportMOCKRepository(configuration));
        }
        public IActionResult Index()
        {
            var model = new TransportSelectionViewModel();
            return View(model);
        }
        //public IActionResult GetExportData(string agent,DateTime begindate,DateTime enddate)
        //{
        //    return PartialView();
        //}
        public JsonResult GetExportData(TransportSelectionViewModel selectionViewModel)
        {
            var model = _exportManager.GetExports(selectionViewModel.BeginDate, selectionViewModel.EndDate, selectionViewModel.AgentName);
            //return Json(Newtonsoft.Json.JsonConvert.SerializeObject(model));
            return Json(model);
        }
        public IActionResult GetExport(string fileNumber)
        {
            var modelExport = _exportManager.GetExport(fileNumber);
            var model = new AirTransportInfo()
            {

            };
            return PartialView("TransportAirFormPartial", model);
        }
        public IActionResult GetGroundTransport(string fileNumber)
        {
            var modelExport = _exportManager.GetExport(fileNumber);
            var model = new GroundTransportInfo()
            {
                FileNumber = fileNumber,
                Agent = new Agency()
                {
                    Id=999,
                    AgencyDescription = "deeededddedeaswww",
                    AgencyTitle = "asdasgfsadgfas"
                }
            };
            return Json(model, Helpers.JsonHelper.jsonSerializerSettings);
        }
        public IActionResult GetAirTransport(string fileNumber)
        {
            var modelExport = _exportManager.GetExport(fileNumber);
            var model = new AirTransportInfo()
            {
                FileNumber = fileNumber,
                ConsignmentDate = DateTime.Now,
                EstimatedArrivalDate = DateTime.Now.AddDays(4),
               
            };
            return Json(model, Helpers.JsonHelper.jsonSerializerSettings);
        }
        public IActionResult GetSeaTransport(string fileNumber)
        {
            var modelExport = _exportManager.GetExport(fileNumber);
            var model = new SeaTransportInfo()
            {
                FileNumber = fileNumber,
                ConsignmentDate = DateTime.Now,
                EstimatedArrivalDate = DateTime.Now.AddDays(4),
                Agent = new Agency()
                {
                    Id = 888,
                    AgencyDescription = "deeddee",
                    AgencyTitle = "asdasfasg",
                }

            };
            return Json(model, Helpers.JsonHelper.jsonSerializerSettings);
        }
        const string SaveSuccessContent = "OK: Kayıt Başarılı";
        const string SaveErrorContent = "ERROR: Kayıt Başarısız";
        [HttpPut]
        public IActionResult PutGroundTransport([FromBody] GroundTransportInfo transportInfo)
        {
            
            return Content(SaveSuccessContent);
        }
        [HttpPut]
        public IActionResult PutAirTransport([FromBody] AirTransportInfo transportInfo)
        {
            return BadRequest(SaveErrorContent);
        }
        [HttpPut]
        public IActionResult PutSeaTransport([FromBody] SeaTransportInfo transportInfo)
        {
            return Content(SaveSuccessContent);
        }
    }
}
