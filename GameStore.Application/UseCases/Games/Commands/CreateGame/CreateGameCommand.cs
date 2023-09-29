using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Picture { get; set; }
        public int UserId { get; set; }
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
            Game game = _mapper.Map<Game>(request);
            await _context.Games.AddAsync(game, cancellationToken);
            await _context.SaveChangesAsync();

            return game.Id;
        }
    }
}
