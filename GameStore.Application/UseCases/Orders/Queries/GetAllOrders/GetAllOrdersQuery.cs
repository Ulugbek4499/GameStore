using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.UseCases.Orders.Queries.GetAllOrders
{
    public record GetAllOrdersQuery : IRequest<OrderResponse[]>;

    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrderResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllOrdersQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<OrderResponse[]> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _context.Orders.ToArrayAsync();

            return _mapper.Map<OrderResponse[]>(Orders);
        }
    }
}
