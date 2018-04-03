using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.BLL.Interfaces;
using Chart.BLL.DTO;
using Chart.BLL.BussinessModels;
using Chart.DAL.Entities;
using Chart.DAL.Interfaces;


namespace Chart.BLL.Services
{
   public class DataService: IDataService
    {
        private IUnitOfWork Database { get; set; }

        public DataService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<List<ChartDataDTO>> GetDataAsync(ParamDTO paramDto)
        {
            var t = await Task.Run(() =>
            {
                var paramsCheck = Database.Params.GetAll()
                    .Where(p => p.CoefficientA == paramDto.CoefficientA)
                    .Where(p => p.CoefficientB == paramDto.CoefficientB)
                    .Where(p => p.CoefficientC == paramDto.CoefficientC)
                    .Where(p => p.SizeFrom == paramDto.SizeFrom)
                    .Where(p => p.SizeTo == paramDto.SizeTo)
                    .Where(p => p.Step == paramDto.Step);

                if (paramsCheck.Any())
                {

                    return FindData(paramsCheck.First().ParamId);
                }
                else
                {
                    return AddInDb(paramDto);
                }
            });
            return t;
            
        }

        public List<ChartDataDTO> AddInDb(ParamDTO paramDto)
        {
           paramDto.ParamId= SaveParams(paramDto).ParamId;
            return CalculateData(paramDto);
        }

        Param SaveParams(ParamDTO paramDto)
        {
            Param _param = new Param
            {
                CoefficientA = paramDto.CoefficientA,
                CoefficientB = paramDto.CoefficientB,
                CoefficientC = paramDto.CoefficientC,
                SizeFrom = paramDto.SizeFrom,
                SizeTo = paramDto.SizeTo,
                Step = paramDto.Step
            };
            Database.Params.Create(_param);
            Database.Save();
            return _param;
        }
        List<ChartDataDTO> CalculateData(ParamDTO paramsDto)
        {
            Calculation calculation = new Calculation(paramsDto);
            var data = calculation.CalculationOfPoints();
            SaveData(paramsDto, data);
            return data;
        }

        void SaveData(ParamDTO paramsDto, List<ChartDataDTO> chartDto)
        {
            var Param = Database.Params.Get(paramsDto.ParamId);
            foreach (var c in chartDto)
            {
                var data = new ChartData()
                {
                    Param = Param,
                    PointY = c.PointY,
                    PointX = c.PointX
                };
                Database.Data.Create(data);
            }
            Database.Save();

        }
        List<ChartDataDTO> FindData(int id)
        {
            var Param = Database.Params.Get(id);
            var chartData = Database.Data.Find(d => d.Param == Param);
            List<ChartDataDTO> data = new List<ChartDataDTO>();
            foreach (var c in chartData)
            {
                data.Add(new ChartDataDTO(c.PointX, c.PointY, c.Id));
            }
            return data;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

      
       

    }
}
