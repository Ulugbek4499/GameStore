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

        async Task IRequestHandler<UpdateGameCommand>.Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == request.Id);

            if (game == null)
            {
                throw new NotFoundException(nameof(Game), request.Id);
            }

            // Update game properties from the request
            _mapper.Map(request, game);

            // Update genres as needed based on GenreIds in the request
            if (request.GenreIds != null)
            {
                var selectedGenres = await _context.Genres.Where(g => request.GenreIds.Contains(g.Id)).ToListAsync();

                // Update the game's genres
                game.Genres = selectedGenres;
            }
            else
            {
                // If no genres are selected, you can handle it here (e.g., remove all genres from the game)
                game.Genres.Clear();
            }

            // Update the game's photo if a new one is provided
            if (request.Picture is not null && request.Picture.Length > 0)
            {
                var gamePhotoFolder = Path.Combine("GamePictures");
                if (!Directory.Exists(gamePhotoFolder))
                {
                    Directory.CreateDirectory(gamePhotoFolder);
                }

                // Generate a unique filename based on the game's name or ID
                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Picture.FileName)}";
                string gamePhotoImagePath = Path.Combine(_environment.WebRootPath, gamePhotoFolder, uniqueFileName);

                using (var fs = new FileStream(gamePhotoImagePath, FileMode.Create))
                {
                    await request.Picture.CopyToAsync(fs);
                    game.Picture = Path.Combine(gamePhotoFolder, uniqueFileName); // Update the relative path in the database
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
