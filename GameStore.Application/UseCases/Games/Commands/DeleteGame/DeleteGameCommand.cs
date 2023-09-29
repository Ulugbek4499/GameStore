using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Games.Commands.DeleteGame
{
    public record DeleteGameCommand(int Id) : IRequest;
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGameCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            Game? game = await _context.Games.FindAsync(request.Id, cancellationToken);

            if (game is null)
                throw new NotFoundException(nameof(game), request.Id);

            _context.Games.Remove(game);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
