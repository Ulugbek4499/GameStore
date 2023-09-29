using AutoMapper;
using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.UseCases.Genres.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<int>
    {
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

    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateGenreCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            Genre Genre = _mapper.Map<Genre>(request);
            await _context.Genres.AddAsync(Genre, cancellationToken);
            await _context.SaveChangesAsync();

            return Genre.Id;
        }
    }
}
