using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.States;
using MediatR;

namespace GameStore.Application.UseCases.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PaymentType PaymentType { get; set; }
        public string? Comment { get; set; }
        public int CartId { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateOrderCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await _context.Orders.FindAsync(request.Id);
            _mapper.Map(request, order);

            if (order is null)
                throw new NotFoundException(nameof(order), request.Id);

            var Cart = await _context.Carts.FindAsync(request.CartId);

            if (Cart is null)
                throw new NotFoundException(nameof(Cart), request.CartId);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
