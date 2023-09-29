using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int Id) : IRequest<OrderResponse>;

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetOrderByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var Order = FilterIfOrderExsists(request.Id);

            var result = _mapper.Map<OrderResponse>(Order);
            return await Task.FromResult(result);
        }

        private Order FilterIfOrderExsists(int id)
            => _dbContext.Orders
                .Find(id) ?? throw new NotFoundException(
                    " There is no Order with this Id. ");
    }
}
