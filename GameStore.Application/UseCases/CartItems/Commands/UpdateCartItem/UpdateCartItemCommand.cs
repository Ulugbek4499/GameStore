using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem
{
    public class UpdateCartItemCommand : IRequest
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int GameId { get; set; }
        public int CartId { get; set; }
    }

    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCartItemCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _context.CartItems.FindAsync(request.Id);
            _mapper.Map(request, cartItem);

            if (cartItem is null)
                throw new NotFoundException(nameof(cartItem), request.Id);

            var Game = await _context.Games.FindAsync(request.GameId);

            if (Game is null)
                throw new NotFoundException(nameof(Game), request.GameId);

            var Cart = await _context.Carts.FindAsync(request.CartId);

            if (Cart is null)
                throw new NotFoundException(nameof(Cart), request.CartId);


            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
