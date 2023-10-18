using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem
{
    public class UpdateCartItemCommand : IRequest
    {
        public int Id { get; set; }
        public int Count { get; set; } = 1;
        public int CardId { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
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

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
