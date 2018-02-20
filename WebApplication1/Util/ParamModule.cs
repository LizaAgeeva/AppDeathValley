using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chart.BLL.Interfaces;
using Chart.BLL.Services;
using Ninject.Modules;

namespace Chart.WEB.Util
{
    public class ParamModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IDataService>().To<DataService>();
        }
    }
}