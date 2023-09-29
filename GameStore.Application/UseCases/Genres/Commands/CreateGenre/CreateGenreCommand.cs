using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
    }

    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateGenreCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            Genre genre = _mapper.Map<Genre>(request);
            await _context.Genres.AddAsync(genre, cancellationToken);
            await _context.SaveChangesAsync();

            return genre.Id;
        }
    }
}
