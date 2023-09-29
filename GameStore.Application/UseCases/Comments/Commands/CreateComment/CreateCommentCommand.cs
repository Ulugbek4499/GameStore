using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateCommentCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync();

            return comment.Id;
        }
    }
}
