using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Carts.Commands.CreateCart;

public class CreateCartCommand : IRequest<int>
{
    public string UserId { get; set; }
    public List<int>? GameIds { get; set; }
}

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public CreateCartCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        Cart cart = _mapper.Map<Cart>(request);
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync();

        return cart.Id;
    }
}
