using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Genres.Commands.DeleteGenre
{
    public record DeleteGenreCommand(int Id) : IRequest;
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGenreCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            Genre? Genre = await _context.Genres.FindAsync(request.Id, cancellationToken);

            if (Genre is null)
                throw new NotFoundException(nameof(Genre), request.Id);

            _context.Genres.Remove(Genre);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
