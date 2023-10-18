using AutoMapper;
using GameStore.Application.UseCases.Orders;
using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<OrderResponse, Order>().ReverseMap();
        }
    }
}
