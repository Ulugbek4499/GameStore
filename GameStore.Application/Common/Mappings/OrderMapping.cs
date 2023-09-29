using AutoMapper;
using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using GameStore.Application.UseCases.Orders.Commands.DeleteOrder;
using GameStore.Application.UseCases.Orders.Commands.UpdateOrder;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<DeleteOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
            CreateMap<OrderResponse, Order>().ReverseMap();
        }
    }
}
