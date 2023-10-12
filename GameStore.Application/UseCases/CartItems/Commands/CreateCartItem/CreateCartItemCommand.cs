using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.Carts.Commands.CreateCart;
using GameStore.Application.UseCases.Carts.Queries.GetCartById;
using GameStore.Application.UseCases.Comments.Queries.GetCommentById;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Identity;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.CreateCartItem
{
    public class CreateCartItemCommand:IRequest<int>
    {
        public int Count { get; set; } = 1;
        public int CardId { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
    }

    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IApplicationUser _applicationUser;
        private readonly IMediator _mediator;

        public CreateCartItemCommandHandler(IMapper mapper, IApplicationDbContext context, IApplicationUser applicationUser, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
            _applicationUser = applicationUser;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            CreateCartCommand Cart = new CreateCartCommand();
            Cart.UserId = request.UserId;

            await _mediator.Send(Cart);

            CartItem cartItem = _mapper.Map<CartItem>(request);
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync(cancellationToken);

            return cartItem.Id;
        }
    }
}
