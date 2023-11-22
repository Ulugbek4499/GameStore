using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.IsDeleteComment
{
    public record IsDeletedCommentCommand(int Id) : IRequest;

    public class IsDeletedCommentCommandHandler : IRequestHandler<IsDeletedCommentCommand>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public IsDeletedCommentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(IsDeletedCommentCommand request, CancellationToken cancellationToken)
        {
            var Comment = _dbContext.Comments.Find(request.Id);
            
            if (!Comment.IsDeleted)
            {
                Comment.IsDeleted = true;
            }

            _mapper.Map(request, Comment);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
