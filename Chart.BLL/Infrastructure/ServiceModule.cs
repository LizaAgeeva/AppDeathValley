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
        //using Singleton
        private string _connectionString;
        private static ServiceModule service;
        private ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public static ServiceModule GetInstance(string connectionString)
        {
            // для исключения возможности создания двух объектов 
            // при многопоточном приложении
            if (service == null)
            {
                lock (typeof(ServiceModule))
                {
                    if (service == null)
                        service = new ServiceModule(connectionString);
                }
            }

            return service;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);

        }
    }
}
