using GameStore.Application.UseCases.Games.Commands.CreateGame;
using GameStore.Application.UseCases.Games.Commands.DeleteGame;
using GameStore.Application.UseCases.Games.Commands.UpdateGame;
using GameStore.Application.UseCases.Games.Queries.GetAllGames;
using GameStore.Application.UseCases.Games.Queries.GetGameById;
using GameStore.Application.UseCases.Genres;
using GameStore.Application.UseCases.Genres.Queries.GetAllGenres;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class GameController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateGame()
        {
            GenreResponse[] genres = await Mediator.Send(new GetAllGenresQuery());
            ViewData["Genres"] = genres;

            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateGame([FromForm] CreateGameCommand Game)
        {
            await Mediator.Send(Game);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllGames()
        {
            var Games = await Mediator.Send(new GetAllGamesQuery());

            return View(Games);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateGame(int Id)
        {
            var Game = await Mediator.Send(new GetGameByIdQuery(Id));
            GenreResponse[] genres = await Mediator.Send(new GetAllGenresQuery());
            ViewData["Genres"] = genres;

            return View(Game);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateGame([FromForm] UpdateGameCommand Game)
        {
            await Mediator.Send(Game);
            return RedirectToAction("Index", "Home");
        }

        public async ValueTask<IActionResult> DeleteGame(int Id)
        {
            await Mediator.Send(new DeleteGameCommand(Id));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewGame(int id)
        {
            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return View("ViewGame", Game);
        }
    }
}
