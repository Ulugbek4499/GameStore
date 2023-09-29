using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Queries.GetCartItemById
{
    public record GetCartItemByIdQuery(int Id) : IRequest<CartItemResponse>;

    public class GetCartItemByIdQueryHandler : IRequestHandler<GetCartItemByIdQuery, CartItemResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetCartItemByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CartItemResponse> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
        {
            var CartItem = FilterIfCartItemExsists(request.Id);

            var result = _mapper.Map<CartItemResponse>(CartItem);
            return await Task.FromResult(result);
        }

        private CartItem FilterIfCartItemExsists(int id)
            => _dbContext.CartItems
                .Find(id) ?? throw new NotFoundException(
                    " There is no CartItem with this Id. ");
    }
}
