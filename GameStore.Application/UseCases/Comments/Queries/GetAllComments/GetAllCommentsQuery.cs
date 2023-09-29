using System.Data.Entity;
using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.CartItems.Response;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Queries.GetAllComments
{
    public record GetAllCommentsQuery : IRequest<CommentResponse[]>;

    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, CommentResponse[]>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllCommentsQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CommentResponse[]> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var Comments = await _context.Comments.ToArrayAsync();

            return _mapper.Map<CommentResponse[]>(Comments);
        }
    }
}
