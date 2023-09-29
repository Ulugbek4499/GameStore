using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public DateTime GameStartDate { get; set; }
        public DateTime PaymentStartDate { get; set; }

        public decimal TotalAmountOfGame { get; set; }
        public decimal InAdvancePaymentOfGame { get; set; }
        public int NumberOfMonths { get; set; }

        public int HomeId { get; set; }
        public int CustomerId { get; set; }
        public int FounderId { get; set; }
    }

    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateGameCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            Game? Game = await _context.Games.FindAsync(request.Id);
            _mapper.Map(request, Game);

            if (Game is null)
                throw new NotFoundException(nameof(Game), request.Id);

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
