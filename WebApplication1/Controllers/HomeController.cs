using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chart.WEB.Models;
using Chart.BLL.Infrastructure;
using Chart.BLL.Interfaces;
using Chart.BLL.DTO;
using AutoMapper;


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

        [HttpPost]
        public JsonResult JsonDataChart(Params model)
        {
         
            if (ModelState.IsValid)
            {
                var param = Mapper.Map<Params, ParamDTO>(model);
                var result = _DataService.GetData(param);

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