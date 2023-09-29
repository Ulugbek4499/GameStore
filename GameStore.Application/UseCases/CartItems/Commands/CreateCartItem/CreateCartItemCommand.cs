using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.CreateCartItem
{
    public class CreateCartItemCommand : IRequest<int>
    {
        public int Count { get; set; }
        public int GameId { get; set; }
        public int CartId { get; set; }
    }

    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateCartItemCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem cartItem = _mapper.Map<CartItem>(request);
            await _context.CartItems.AddAsync(cartItem, cancellationToken);
            await _context.SaveChangesAsync();

            return cartItem.Id;
        }
    }
}
