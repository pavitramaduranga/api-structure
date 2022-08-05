using AutoMapper;

namespace WorkdayCalender.Api.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Infastructure.Entities.Holiday, Core.Models.Holiday>().ReverseMap();
        }
    }
}
