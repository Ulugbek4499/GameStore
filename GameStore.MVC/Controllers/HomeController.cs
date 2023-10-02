using System.Diagnostics;
using GameStore.Application.UseCases.Games.Queries.GetAllGames;
using GameStore.Application.UseCases.Genres.Queries.GetAllGenres;
using GameStore.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IMediator? _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
                var Games = await Mediator.Send(new GetAllGamesQuery());
                ViewData["Games"] = Games;

                var Genres = await Mediator.Send(new GetAllGenresQuery());
                ViewData["Genres"] = Genres;

            return View();
        }
   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}