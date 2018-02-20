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
    public class ParamRepository : IRepository<Param>
    {
        private ChartContext db;
        public ParamRepository(ChartContext context)
        {
            this.db = context;
        }
        public IEnumerable<Param> GetAll()
        {
            return db.Params;
        }
            public Param Get(int id)
            {
                return db.Params.Find(id);
            }
            public void Create(Param param)
        {
            db.Params.Add(param);
        }
        public IEnumerable<Param> Find(Func<Param, Boolean> predicate)
        {
            return db.Params.Where(predicate).ToList();
        }

    }
}
