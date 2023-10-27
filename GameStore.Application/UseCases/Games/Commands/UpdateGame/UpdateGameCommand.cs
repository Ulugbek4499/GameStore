using AutoMapper;
using GameStore.Application.Common.Exceptions;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameStore.Application.UseCases.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Picture { get; set; }
        public ICollection<int> GenreIds { get; set; }
    }

    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public UpdateGameCommandHandler(IMapper mapper, IApplicationDbContext context, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
            _environment = environment;
        }

        public async Task Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games
                .Include(g => g.Genres) // Ensure genres are loaded for this game
                .FirstOrDefaultAsync(g => g.Id == request.Id);

            if (game == null)
            {
                throw new NotFoundException(nameof(Game), request.Id);
            }

            // Update game properties
            _mapper.Map(request, game);

            // Clear existing genre associations
            game.Genres.Clear();

            if (request.GenreIds != null && request.GenreIds.Any())
            {
                // Retrieve selected genres
                var selectedGenres = await _context.Genres
                    .Where(g => request.GenreIds.Contains(g.Id))
                    .ToListAsync();

                // Associate selected genres with the game
                game.Genres = selectedGenres;
            }

            if (request.Picture is not null && request.Picture.Length > 0)
            {
                var gamePhotoFolder = Path.Combine("GamePictures");
                if (!Directory.Exists(gamePhotoFolder))
                {
                    Directory.CreateDirectory(gamePhotoFolder);
                }

                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Picture.FileName)}";
                string gamePhotoImagePath = Path.Combine(_environment.WebRootPath, gamePhotoFolder, uniqueFileName);

                using (var fs = new FileStream(gamePhotoImagePath, FileMode.Create))
                {
                    await request.Picture.CopyToAsync(fs);
                    game.Picture = Path.Combine(gamePhotoFolder, uniqueFileName);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
