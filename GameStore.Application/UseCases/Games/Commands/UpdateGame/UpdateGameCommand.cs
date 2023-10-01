using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Picture { get; set; }
        public int UserId { get; set; }
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
            Game? game = await _context.Games.FindAsync(request.Id);
            _mapper.Map(request, game);

            if (game is null)
                throw new NotFoundException(nameof(game), request.Id);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
