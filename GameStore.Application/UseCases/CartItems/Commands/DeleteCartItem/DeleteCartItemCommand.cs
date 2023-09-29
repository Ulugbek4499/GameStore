using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.DeleteCartItem
{
    public record DeleteCartItemCommand(int Id) : IRequest;
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCartItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _context.CartItems.FindAsync(request.Id, cancellationToken);

            if (cartItem is null)
                throw new NotFoundException(nameof(cartItem), request.Id);

            _context.CartItems.Remove(cartItem);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
