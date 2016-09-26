using AutoMapper;
using ServiceStation.Domain.Model;
using ServiceStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            });
            MapperConfigOrder = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Orders, OrderViewModel>().ReverseMap();
            });
            MapperConfigCar = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RelatedCars, CarViewModel>().ReverseMap();
            });
        }
    }
}