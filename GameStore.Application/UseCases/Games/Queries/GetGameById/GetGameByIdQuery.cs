using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Games.Queries.GetGameById
{
    public record GetGameByIdQuery(int Id) : IRequest<GameResponse>;

    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetGameByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GameResponse> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var Game = FilterIfGameExsists(request.Id);

            var result = _mapper.Map<GameResponse>(Game);
            return await Task.FromResult(result);
        }

        private Game FilterIfGameExsists(int id)
            => _dbContext.Games
                .Find(id) ?? throw new NotFoundException(
                    " There is no Game with this Id. ");
    }
}
