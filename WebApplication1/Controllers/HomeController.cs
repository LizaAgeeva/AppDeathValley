using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chart.WEB.Models;
using Chart.BLL.Infrastructure;
using Chart.BLL.Interfaces;
using Chart.BLL.DTO;
using Chart.BLL.BussinessModels;
using AutoMapper;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Chart.WEB.Controllers
{
    public class HomeController : Controller
    {
      

        private IDataService _DataService;

        public HomeController(IDataService DataService)
        {
            _DataService = DataService;
        }

        public ActionResult Chart()
        {
            return View();
        }
        public ActionResult TypeChart()
        {
            // Factory Method 
            FactoryMethod factory1 = new FactoryMethod("Pie1");
            string type1 = factory1.typeChart;
            FactoryMethod factory2 = new FactoryMethod("Line1"); //edited this row
            string type2 = factory2.typeChart;
            ViewBag.Message = type1 + " and " + type2;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> JsonDataChart(Params model)
        {
         
            if (ModelState.IsValid)
            {
                var param = Mapper.Map<Params, ParamDTO>(model);
                var result = await _DataService.GetDataAsync(param);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelStateErrors = this.ModelState.Keys.SelectMany(key => this.ModelState[key].Errors);
                var message = "";

                foreach (var modelStateError in modelStateErrors)
                {
                    message += modelStateError.ErrorMessage + Environment.NewLine;
                }

                return Json(new { success = false, response = message });
            }

        }






       
    }
}