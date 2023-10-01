using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Genres.Queries.GetGenreById
{
    public record GetGenreByIdQuery(int Id) : IRequest<GenreResponse>;

    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetGenreByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GenreResponse> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var Genre = FilterIfGenreExsists(request.Id);

            var result = _mapper.Map<GenreResponse>(Genre);
            return await Task.FromResult(result);
        }

        private Genre FilterIfGenreExsists(int id)
            => _dbContext.Genres
                .Find(id) ?? throw new NotFoundException(
                    " There is no Genre with this Id. ");
    }
}
