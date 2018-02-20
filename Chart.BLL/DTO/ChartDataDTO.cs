using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.BLL.DTO
{
    public class ChartDataDTO
    {
        public int Id { get; set; }
        public int ParamId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }

        public ChartDataDTO (double x, double y, int id)
        {
            PointX = x;
            PointY = y;
            ParamId = id;
        }
        
    }
}
