using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities.Identity;
using MediatR;

namespace GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem
{
    public class UpdateCartItemDownCommand : IRequest
    {
        public int Id { get; set; }
        public int Count { get; set; }=1;
    }

    public class UpdateCartItemDownCommandHandler : IRequestHandler<UpdateCartItemDownCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCartItemDownCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateCartItemDownCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _context.CartItems.FindAsync(request.Id);
            cartItem.Count -= request.Count;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
