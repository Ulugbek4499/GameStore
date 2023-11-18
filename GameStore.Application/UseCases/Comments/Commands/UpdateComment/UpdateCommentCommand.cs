using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int? GameId { get; set; }
        public int? ParentCommentId { get; set; }
    }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCommentCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment? comment = await _context.Comments.FindAsync(request.Id);
            int parentId = comment.ParentCommentId ?? 0;

            if (parentId != 0)
            {
                request.ParentCommentId = parentId;
            }

            _mapper.Map(request, comment);

            if (comment is null)
                throw new NotFoundException(nameof(comment), request.Id);

            var Game = await _context.Games.FindAsync(request.GameId);

            if (Game is null)
                throw new NotFoundException(nameof(Game), request.GameId);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
