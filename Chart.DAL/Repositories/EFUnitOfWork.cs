using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.DAL.EF;
using Chart.DAL.Entities;
using Chart.DAL.Interfaces;

namespace Chart.DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private ChartContext db;
        private ChartDataRepository chartDataRepository;
        private ParamRepository paramRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ChartContext(connectionString);
        }
        public IRepository<ChartData> Data
        {
            get
            {
                if (chartDataRepository == null)
                    chartDataRepository = new ChartDataRepository(db);
                return chartDataRepository;
            }
        }
        public IRepository<Param> Params
        {
            get
            {
                if (paramRepository == null)
                    paramRepository = new ParamRepository(db);
                return paramRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
