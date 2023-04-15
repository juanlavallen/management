using Application.Features.Orders.Commands.AddOrder;
using Application.Features.Orders.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<AddOrderCommand, Order>();
        }
    }
}