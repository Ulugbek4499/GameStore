using AutoMapper;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace GameStore.Application.UseCases.Games.Commands.CreateGame;
public class CreateGameCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public IFormFile? Picture { get; set; }
    public ICollection<int> GenreIds { get; set; }
}

public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public CreateGameCommandHandler(IMapper mapper, IApplicationDbContext context, IConfiguration configuration, IWebHostEnvironment environment)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
        _environment = environment;
    }

    public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        Game game = _mapper.Map<Game>(request);

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
                game.Picture = Path.Combine(gamePhotoFolder, uniqueFileName); // Store the relative path in the database
            }
        }

        await _context.Games.AddAsync(game, cancellationToken);
        await _context.SaveChangesAsync();

        return game.Id;
    }
}
