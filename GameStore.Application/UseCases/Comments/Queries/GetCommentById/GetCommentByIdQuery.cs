using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Queries.GetCommentById
{
    public record GetCommentByIdQuery(int Id) : IRequest<CommentResponse>;

    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentResponse>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public GetCommentByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CommentResponse> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var Comment = _dbContext.Comments.Find(request.Id);

            var result = _mapper.Map<CommentResponse>(Comment);
            return await Task.FromResult(result);
        }

    }
}
