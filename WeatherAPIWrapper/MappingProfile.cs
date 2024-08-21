using AutoMapper;
using WeatherAPIWrapper.Models;
using WeatherAPIWrapper.Models.DTOs;

namespace WeatherAPIWrapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<WeatherDataDto, WeatherData>()
                .ForMember(dest => dest.TodayWeather, opt => opt.MapFrom(src => src.Days.FirstOrDefault()));
            CreateMap<DayDataDto, DayData>();
        }
    }
}
