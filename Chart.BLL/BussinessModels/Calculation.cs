using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.BLL.DTO;

namespace Chart.BLL.BussinessModels
{
    public class Calculation
    {
       
        private ParamDTO _param;
        private List<ChartDataDTO> _chartData;
        
        public Calculation (ParamDTO param)
        {
            _param = param;
            _chartData = new List<ChartDataDTO>();
        }

        public List<ChartDataDTO> CalculationOfPoints()
        {
            for (double x = _param.SizeFrom; x <= _param.SizeTo; x += _param.Step)
            {
                double y = _param.CoefficientA * x * x + _param.CoefficientB * x + _param.CoefficientC;
                _chartData.Add(new ChartDataDTO ( x, y, _param.ParamId ));
            }
            return _chartData;
        }
       
    }
}
