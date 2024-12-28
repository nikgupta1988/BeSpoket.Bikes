using AutoMapper;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;

namespace BeSpoked.Bikes.API.Automapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SalesPerson, AddorUpdateSalePerson>().ReverseMap();
        }
    }
}
