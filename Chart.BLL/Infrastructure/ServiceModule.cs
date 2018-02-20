using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.DAL.Interfaces;
using Chart.DAL.Repositories;
using Ninject.Modules;

namespace Chart.BLL.Infrastructure
{
    public class ServiceModule: NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);

        }
    }
}
