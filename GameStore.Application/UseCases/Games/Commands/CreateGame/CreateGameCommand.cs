using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<int>
    {
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

    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateGameCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            Game Game = _mapper.Map<Game>(request);
            await _context.Games.AddAsync(Game, cancellationToken);
            await _context.SaveChangesAsync();

            return Game.Id;
        }
    }
}
