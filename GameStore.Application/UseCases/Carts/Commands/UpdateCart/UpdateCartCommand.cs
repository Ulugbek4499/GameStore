using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Carts.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<int>? GameIds { get; set; }
    }

    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCartCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            Cart? Cart = await _context.Carts.FindAsync(request.Id);
            _mapper.Map(request, Cart);

            if (Cart is null)
                throw new NotFoundException(nameof(Cart), request.Id);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
