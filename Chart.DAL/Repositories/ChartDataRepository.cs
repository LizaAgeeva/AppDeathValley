using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.DAL.EF;
using Chart.DAL.Entities;
using Chart.DAL.Interfaces;
using System.Data.Entity;

namespace Chart.DAL.Repositories
{
   public class ChartDataRepository:IRepository<ChartData>
    {
        private ChartContext db;
        public ChartDataRepository(ChartContext context)
        {
            this.db = context;
        }
        public IEnumerable<ChartData> GetAll()
        {
            return db.Data;
        }
        public ChartData Get(int id)
        {
            return db.Data.Find(id);
        }
        public void Create(ChartData chartData)
        {
            db.Data.Add(chartData);
        }
        public IEnumerable<ChartData> Find(Func<ChartData, Boolean> predicate)
        {
            return db.Data.Where(predicate).ToList();
        }
    }
}
