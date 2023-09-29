using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string CommentNumber { get; set; }
        public DateTime CommentStartDate { get; set; }
        public DateTime PaymentStartDate { get; set; }

        public decimal TotalAmountOfComment { get; set; }
        public decimal InAdvancePaymentOfComment { get; set; }
        public int NumberOfMonths { get; set; }

        public int HomeId { get; set; }
        public int CustomerId { get; set; }
        public int FounderId { get; set; }
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
            Comment Comment = _mapper.Map<Comment>(request);
            await _context.Comments.AddAsync(Comment, cancellationToken);
            await _context.SaveChangesAsync();

            return Comment.Id;
        }
    }
}
