using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Chart.BLL.DTO;
using Chart.WEB.Models;

namespace WebApplication1.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Params, ParamDTO>();
            });
        }
    }
}