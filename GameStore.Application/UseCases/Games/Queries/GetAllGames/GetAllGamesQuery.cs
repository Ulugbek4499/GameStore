using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.UseCases.Games.Queries.GetAllGames
{
    public record GetAllGamesQuery : IRequest<GameResponse[]>;

    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, GameResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllGamesQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GameResponse[]> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var Games = await _context.Games.ToArrayAsync();

            return _mapper.Map<GameResponse[]>(Games);
        }
    }
}
