using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.DAL.Entities;

namespace Chart.DAL.Interfaces
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<Param> Params { get; }
        IRepository<ChartData> Data { get; }
        void Save();
    }
     
}
