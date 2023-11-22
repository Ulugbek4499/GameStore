using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.RestoreDeleteComment
{
    public record RestoreDeleteCommentCommand(int Id) : IRequest;

    public class RestoreDeleteCommentCommandHandler : IRequestHandler<RestoreDeleteCommentCommand>
    {
        IApplicationDbContext _dbContext;
        IMapper _mapper;

        public RestoreDeleteCommentCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(RestoreDeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var Comment = _dbContext.Comments.Find(request.Id);

            if (Comment.IsDeleted)
            {
                Comment.IsDeleted = false;
            }

            _mapper.Map(request, Comment);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
