using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.UseCases.Genres.Queries.GetAllGenres
{
    public record GetAllGenresQuery : IRequest<GenreResponse[]>;

    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, GenreResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllGenresQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GenreResponse[]> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var Genres = await _context.Genres.ToArrayAsync();

            return _mapper.Map<GenreResponse[]>(Genres);
        }
    }
}
