using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.DAL.Entities;
using System.Data.Entity;

namespace Chart.DAL.EF
{
    public class ChartContext: DbContext
    {
        public DbSet<ChartData> Data { get; set; }
        public DbSet<Param> Params { get; set; }

        static ChartContext()
        {
            Database.SetInitializer<ChartContext> (new ChartDbInitialazer());
        }
        public ChartContext(string connectionString)
            : base(connectionString)
        {

        }

    }
     public class ChartDbInitialazer : DropCreateDatabaseIfModelChanges<ChartContext>
    {
        protected override void Seed(ChartContext db)
        {
            db.Params.Add(new Param { CoefficientA = 1, CoefficientB = 2, CoefficientC = 3, SizeFrom = -10, SizeTo = 10, Step = 1 });
            db.Params.Add(new Param { CoefficientA = 3, CoefficientB = 2, CoefficientC = 1, SizeFrom = 0, SizeTo = 10, Step = 1 });
            db.Params.Add(new Param { CoefficientA = 1, CoefficientB = 5, CoefficientC = -3, SizeFrom = -10, SizeTo = 10, Step = 0.5 });
            db.SaveChanges();
        }
    }
}
