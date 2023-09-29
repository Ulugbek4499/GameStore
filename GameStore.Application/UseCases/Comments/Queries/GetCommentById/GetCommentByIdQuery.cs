using AutoMapper;
using GameStore.Application.Common.Exceptions;
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
            var Comment = FilterIfCommentExsists(request.Id);

            var result = _mapper.Map<CommentResponse>(Comment);
            return await Task.FromResult(result);
        }

        private Comment FilterIfCommentExsists(int id)
            => _dbContext.Comments
                .Find(id) ?? throw new NotFoundException(
                    " There is no Comment with this Id. ");
    }
}
