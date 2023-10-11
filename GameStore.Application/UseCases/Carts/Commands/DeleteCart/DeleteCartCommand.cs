using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Carts.Commands.DeleteCart
{
    public record DeleteCartCommand(int Id) : IRequest;
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCartCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            Cart? Cart = await _context.Carts.FindAsync(request.Id, cancellationToken);

            if (Cart is null)
                throw new NotFoundException(nameof(Cart), request.Id);

            _context.Carts.Remove(Cart);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
