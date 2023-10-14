using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Application.UseCases.Carts.Queries.GetCartByUserId
{
    public record GetCartByCartItemIdQuery(int Id) : IRequest<CartResponse>;

    public class GetCartByCartItemIdQueryHandler : IRequestHandler<GetCartByCartItemIdQuery, CartResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCartByCartItemIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CartResponse> Handle(GetCartByCartItemIdQuery request, CancellationToken cancellationToken)
        {
            var cart = _dbContext.Carts.FirstOrDefault(c => c.CartItems.Any(item => item.Id == request.Id));

            if (cart == null)
            {
                return new CartResponse(); // Adjust this based on your requirements.
            }

            var result = _mapper.Map<CartResponse>(cart);
            return result;
        }
    }

}
