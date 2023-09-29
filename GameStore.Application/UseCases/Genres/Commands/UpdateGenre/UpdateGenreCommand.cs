using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
    }

    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateGenreCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            Genre? genre = await _context.Genres.FindAsync(request.Id);
            _mapper.Map(request, genre);

            if (genre is null)
                throw new NotFoundException(nameof(genre), request.Id);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
