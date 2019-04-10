using AutoMapper;
using MVC_ParserTestApps;
using MVC_ParserTestApps.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ParserTestApps.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
        //    Mapper.CreateMap<CarModels, CarModelView>();
        //    Mapper.CreateMap<CarModelView, CarModels>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}