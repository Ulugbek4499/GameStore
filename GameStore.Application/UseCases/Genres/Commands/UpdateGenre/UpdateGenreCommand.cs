using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommand : IRequest
    {
        public int Id { get; set; }
        public string GenreNumber { get; set; }
        public DateTime GenreStartDate { get; set; }
        public DateTime PaymentStartDate { get; set; }

        public decimal TotalAmountOfGenre { get; set; }
        public decimal InAdvancePaymentOfGenre { get; set; }
        public int NumberOfMonths { get; set; }

        public int HomeId { get; set; }
        public int CustomerId { get; set; }
        public int FounderId { get; set; }
    }

    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateGenreCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            Genre? Genre = await _context.Genres.FindAsync(request.Id);
            _mapper.Map(request, Genre);

            if (Genre is null)
                throw new NotFoundException(nameof(Genre), request.Id);

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
