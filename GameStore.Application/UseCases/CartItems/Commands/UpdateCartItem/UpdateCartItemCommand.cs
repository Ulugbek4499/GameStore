using System;
using System.Collections.Generic;
using System.Diagnostics.CartItems;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var Home = await _context.Homes.FindAsync(request.HomeId);

            if (Home is null)
                throw new NotFoundException(nameof(Home), request.HomeId);

            var Customer = await _context.Customers.FindAsync(request.CustomerId);

            if (Customer is null)
                throw new NotFoundException(nameof(Customer), request.CustomerId);

            var Founder = await _context.Founders.FindAsync(request.FounderId);

            if (Founder is null)
                throw new NotFoundException(nameof(Founder), request.FounderId);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
