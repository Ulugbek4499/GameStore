using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.Carts;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Carts.Queries.GetCartById
{
    public record GetCartByIdQuery(int Id) : IRequest<CartResponse>;

    public class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, CartResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetCartByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CartResponse> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var Cart = FilterIfCartExsists(request.Id);

            var result = _mapper.Map<CartResponse>(Cart);
            return await Task.FromResult(result);
        }

        private Cart FilterIfCartExsists(int id)
            => _dbContext.Carts
                .Find(id) ?? throw new NotFoundException(
                    " There is no Cart with this Id. ");
    }
}
