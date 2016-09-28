using AutoMapper;
using ServiceStation.Domain.Model;
using ServiceStation.Models;

namespace ServiceStation
{
    public class MappingConfig
    {
        internal static MapperConfiguration MapperConfigClient;
        internal static MapperConfiguration MapperConfigOrder;
        internal static MapperConfiguration MapperConfigCar;
        public static void RegisterMapping()
        {
            MapperConfigClient = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClientCard, ClientCardViewModel>().ReverseMap();
                cfg.CreateMap<ClientCard, CheckClientViewModel>().ReverseMap();
                cfg.CreateMap<ClientCard, ClientCardModifeidViewModel>().ReverseMap();

            });
            MapperConfigOrder = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Orders, OrderViewModel>().ReverseMap();
            });
            MapperConfigCar = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RelatedCars, CarViewModel>().ReverseMap();
                cfg.CreateMap<RelatedCars, CheckCarViewModel>().ReverseMap();
            });
        }
    }
}