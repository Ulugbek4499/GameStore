using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.States;
using MediatR;

namespace GameStore.Application.UseCases.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PaymentType PaymentType { get; set; }
        public string? Comment { get; set; }
        public string UserId { get; set; }
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
            Order order = _mapper.Map<Order>(request);
            var cart = _context.Carts.FirstOrDefault(x => x.UserId == request.UserId && x.CartStatus== CartStatus.OnSale);
            order.Cart = cart;
            order.CartId = cart.Id;

            await _context.Orders.AddAsync(order, cancellationToken);
            cart.CartStatus = CartStatus.Sold;
            await _context.SaveChangesAsync();

            return order.Id;
        }
    }
}
