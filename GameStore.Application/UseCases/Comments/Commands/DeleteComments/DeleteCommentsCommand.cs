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

            foreach (Comment comment in commentsToDelete)
            {
                if (comment.ChildComments is not null)
                {
                    foreach (Comment childComment in comment.ChildComments)
                    {
                        _context.Comments.Remove(childComment);
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                }

                _context.Comments.Remove(comment);
            }
            await _context.SaveChangesAsync(cancellationToken);


            _context.Comments.RemoveRange(commentsToDelete);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
