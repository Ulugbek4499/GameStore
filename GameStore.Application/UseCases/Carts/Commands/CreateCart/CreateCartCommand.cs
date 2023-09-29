using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Carts.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<int>
    {
        public string CartNumber { get; set; }
        public DateTime CartStartDate { get; set; }
        public DateTime PaymentStartDate { get; set; }

        public decimal TotalAmountOfCart { get; set; }
        public decimal InAdvancePaymentOfCart { get; set; }
        public int NumberOfMonths { get; set; }

        public int HomeId { get; set; }
        public int CustomerId { get; set; }
        public int FounderId { get; set; }
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
}
