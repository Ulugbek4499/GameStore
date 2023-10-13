using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Application.UseCases.Carts.Queries.GetCartByUserId
{
    public record GetCartByUserIdQuery(string Id) : IRequest<CartResponse>;

    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdQuery, CartResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCartByUserIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CartResponse> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Fetch the single cart entity based on the provided userId
            var cart = _dbContext.Carts.FirstOrDefault(x => x.UserId == request.Id);

            if (cart == null)
            {
                // Handle the case where no cart is found for the given userId
                // For example, return an empty CartResponse or throw an exception.
                return new CartResponse(); // Adjust this based on your requirements.
            }

            var result = _mapper.Map<CartResponse>(cart);
            return result;
        }
    }

}
