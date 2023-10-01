using System.Data.Entity;
using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Queries.GetAllCartItems
{
    public record GetAllCartItemsQuery : IRequest<CartItemResponse[]>;

    public class GetAllCartItemsQueryHandler : IRequestHandler<GetAllCartItemsQuery, CartItemResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllCartItemsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CartItemResponse[]> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
        {
            var CartItems = await _context.CartItems.ToArrayAsync();

            return _mapper.Map<CartItemResponse[]>(CartItems);
        }
    }
}
