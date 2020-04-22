using System.Collections.Generic;
using AutoMapper;
using Data.DataSources;
using Domain.Entities;
using WebAPI.DTO;

namespace WebAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDataSource>();
            CreateMap<ClientDataSource, Client>();
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Order, OrderDataSource>();
            CreateMap<OrderDataSource, Order>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            
            CreateMap<Guitar, GuitarDataSource>();
            CreateMap<GuitarDataSource, Guitar>();
            CreateMap<Guitar, GuitarDTO>();
            CreateMap<GuitarDTO, Guitar>();
            
            // CreateMap<IEnumerable<Guitar>, IEnumerable<GuitarDataSource>>();
            // CreateMap<IEnumerable<GuitarDataSource>, IEnumerable<Guitar>>();
            // CreateMap<IEnumerable<Guitar>, IEnumerable<GuitarDTO>>();
            // CreateMap<IEnumerable<GuitarDTO>, IEnumerable<Guitar>>();
        }
    }
}