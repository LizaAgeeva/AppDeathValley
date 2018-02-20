using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.DAL.Entities
{
    public class ChartData
    {
       
        public int Id { get; set; }
        public virtual Param Param { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }

       
    }
}
   
