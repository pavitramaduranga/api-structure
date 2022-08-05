using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkdayCalender.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<WorkdayCalender.Infastructure.Entities.Holiday, WorkdayCalender.Core.Models.Holiday>().ReverseMap();
        }
    }
}
