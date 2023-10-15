using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem
{
    public record UpdateCartItemUpCommand(int Id) : IRequest;

    public class UpdateCartItemUpCommandHandler : IRequestHandler<UpdateCartItemUpCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCartItemUpCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateCartItemUpCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _context.CartItems.FindAsync(request.Id);
            cartItem.Count = cartItem.Count+1;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
