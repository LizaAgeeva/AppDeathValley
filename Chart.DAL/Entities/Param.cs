using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.DAL.Entities
{
   public class Param
    {
        public int ParamId { get; set; }
        public double CoefficientA { get; set; }
        public double CoefficientB { get; set; }
        public double CoefficientC { get; set; }
        public double Step { get; set; }
        public double SizeFrom { get; set; }
        public double SizeTo { get; set; }
    }
}
