using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using MediatR;

namespace CartItemStore.Application.UseCases.CartItems.Commands.DeleteCartItem
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
                throw new GameStore.Application.Common.Exceptions.NotFoundException(nameof(cartItem), request.Id);

            _context.CartItems.Remove(cartItem);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
