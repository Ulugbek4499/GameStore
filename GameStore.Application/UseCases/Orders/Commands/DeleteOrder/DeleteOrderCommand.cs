using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Orders.Commands.DeleteOrder
{
    public record DeleteOrderCommand(int Id) : IRequest;
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order? order = await _context.Orders.FindAsync(request.Id, cancellationToken);

            if (order is null)
                throw new NotFoundException(nameof(order), request.Id);

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
