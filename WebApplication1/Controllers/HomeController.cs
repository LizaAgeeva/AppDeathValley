using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
                List<ChartData> pointArray = new List<ChartData>();

                int k = 0;

                for (double x = model.SizeFrom; x <= model.SizeTo; x += model.Step)
                {
                    k++;
                    double y = model.CoefficientA * x * x + model.CoefficientB * x + model.CoefficientC;
                    pointArray.Add(new ChartData { PointX = x, PointY = y });
                }

                return Json(pointArray, JsonRequestBehavior.AllowGet);
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






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}