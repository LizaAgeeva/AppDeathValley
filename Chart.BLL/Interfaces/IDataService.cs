using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.BLL.DTO;

namespace Chart.BLL.Interfaces
{
    public interface IDataService
    {

        List<ChartDataDTO> AddInDb(ParamDTO paramDTO);
        List<ChartDataDTO> GetData(ParamDTO paramDTO);
        void Dispose();
    }
}
