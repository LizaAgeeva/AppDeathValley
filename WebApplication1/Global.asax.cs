using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Chart.BLL.Infrastructure;
using Chart.WEB.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            App_Start.AutoMapperConfig.Initialize();

            NinjectModule paramModule = new ParamModule();
            // NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            NinjectModule serviceModule = ServiceModule.GetInstance("DefaultConnection");
            var kernel = new StandardKernel(paramModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
