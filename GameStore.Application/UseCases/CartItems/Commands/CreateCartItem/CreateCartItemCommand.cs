using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.Carts.Commands.CreateCart;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Identity;
using GameStore.Domain.States;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.CreateCartItem
{
    public class CreateCartItemCommand : IRequest<int>
    {
        public int Count { get; set; } = 0;
        public int? CardId { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
    }

    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CreateCartItemCommandHandler(IMapper mapper, IApplicationDbContext context, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cart = _context.Carts.Single(x => x.UserId == request.UserId && x.CartStatus != CartStatus.Sold);

            if (cart is null)
            {
                CreateCartCommand Cart = new CreateCartCommand();
                Cart.UserId = request.UserId;
                await _mediator.Send(Cart);
                cart = _mapper.Map<Cart>(Cart);
            }

            var existingCartItem = _context.CartItems
                .FirstOrDefault(x => x.Cart.UserId == request.UserId && x.GameId == request.GameId && x.CardId == cart.Id);

            if (existingCartItem != null)
            {
                existingCartItem.Count += request.Count;
                await _context.SaveChangesAsync(cancellationToken);

                return existingCartItem.Id;
            }
            else
            {
                CartItem cartItem = _mapper.Map<CartItem>(request);
                cartItem.CardId = cart.Id;
                cartItem.Cart = cart;
                await _context.CartItems.AddAsync(cartItem);
                await _context.SaveChangesAsync(cancellationToken);

                return cartItem.Id;
            }
        }
    }
}
