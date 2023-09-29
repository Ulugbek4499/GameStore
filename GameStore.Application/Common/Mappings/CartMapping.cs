using AutoMapper;
using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Carts.Commands.CreateCart;
using GameStore.Application.UseCases.Carts.Commands.DeleteCart;
using GameStore.Application.UseCases.Carts.Commands.UpdateCart;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<CreateCartCommand, Cart>().ReverseMap();
            CreateMap<DeleteCartCommand, Cart>().ReverseMap();
            CreateMap<UpdateCartCommand, Cart>().ReverseMap();
            CreateMap<CartResponse, Cart>().ReverseMap();
        }
    }
}
