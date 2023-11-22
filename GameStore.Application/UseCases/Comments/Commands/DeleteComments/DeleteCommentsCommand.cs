using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.UseCases.Comments.Commands.DeleteComments
{
    public record DeleteCommentsCommand : IRequest;
    public class DeleteCommentsCommandHandler : IRequestHandler<DeleteCommentsCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommentsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCommentsCommand request, CancellationToken cancellationToken)
        {
            List<Comment> commentsToDelete = await _context.Comments
                    .Where(comment => comment.IsDeleted)
                    .ToListAsync(cancellationToken);

            _context.Comments.RemoveRange(commentsToDelete);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
