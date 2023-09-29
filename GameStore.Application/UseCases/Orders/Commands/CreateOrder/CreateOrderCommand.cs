using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string OrderNumber { get; set; }
        public DateTime OrderStartDate { get; set; }
        public DateTime PaymentStartDate { get; set; }

        public decimal TotalAmountOfOrder { get; set; }
        public decimal InAdvancePaymentOfOrder { get; set; }
        public int NumberOfMonths { get; set; }

        public int HomeId { get; set; }
        public int CustomerId { get; set; }
        public int FounderId { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateOrderCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order Order = _mapper.Map<Order>(request);
            await _context.Orders.AddAsync(Order, cancellationToken);
            await _context.SaveChangesAsync();

            return Order.Id;
        }
    }
}
