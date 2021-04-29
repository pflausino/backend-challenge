using AutoMapper;
using SquareMetersValue.Domain.Models;
using SquareMetersValue.Domain.ViewModel;

namespace SquareMetersValue.Api.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City,CityViewModel>();
        }
        
    }
}