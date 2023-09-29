using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public int Id { get; set; }
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
            Comment? Comment = await _context.Comments.FindAsync(request.Id);
            _mapper.Map(request, Comment);

            if (Comment is null)
                throw new NotFoundException(nameof(Comment), request.Id);

            var Home = await _context.Homes.FindAsync(request.HomeId);

            if (Home is null)
                throw new NotFoundException(nameof(Home), request.HomeId);

            var Customer = await _context.Customers.FindAsync(request.CustomerId);

            if (Customer is null)
                throw new NotFoundException(nameof(Customer), request.CustomerId);

            var Founder = await _context.Founders.FindAsync(request.FounderId);

            if (Founder is null)
                throw new NotFoundException(nameof(Founder), request.FounderId);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
