using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.DeleteComment
{
    public record DeleteCommentCommand(int Id) : IRequest;
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            Comment? Comment = await _context.Comments.FindAsync(request.Id, cancellationToken);

            if (Comment is null)
                throw new NotFoundException(nameof(Comment), request.Id);

            _context.Comments.Remove(Comment);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
