using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Application.UseCases.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public int? GameId { get; set; }
        public int? ParentCommentId { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateCommentCommandHandler(IMapper mapper, IApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("User Id needed for giving the comment");
                // Handle the case where the user doesn't exist.
                // You can throw an exception or return an appropriate response.
            }

            Comment comment = _mapper.Map<Comment>(request);
            comment.User = user; // Associate the comment with the user
            await _context.Comments.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync();

            return comment.Id;
        }
    }
}
