using AutoMapper;
using GameStore.Application.UseCases.CartItems;
using GameStore.Application.UseCases.CartItems.Commands.CreateCartItem;
using GameStore.Application.UseCases.CartItems.Commands.DeleteCartItem;
using GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem;
using GameStore.Domain.Entities;

namespace GameStore.Application.Common.Mappings
{
    public class CartItemMapping : Profile
    {
        public CartItemMapping()
        {
            CreateMap<CreateCartItemCommand, CartItem>().ReverseMap();
            CreateMap<DeleteCartItemCommand, CartItem>().ReverseMap();
            CreateMap<UpdateCartItemCommand, CartItem>().ReverseMap();
            CreateMap<CartItemResponse, CartItem>().ReverseMap();
        }
    }
}
