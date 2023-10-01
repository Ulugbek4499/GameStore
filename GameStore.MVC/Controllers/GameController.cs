﻿using GameStore.Application.UseCases.Games.Commands.CreateGame;
using GameStore.Application.UseCases.Games.Commands.DeleteGame;
using GameStore.Application.UseCases.Games.Commands.UpdateGame;
using GameStore.Application.UseCases.Games.Queries.GetAllGames;
using GameStore.Application.UseCases.Games.Queries.GetGameById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class GameController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateGame()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateGame([FromForm] CreateGameCommand Game)
        {
            await Mediator.Send(Game);

            return RedirectToAction("GetAllGames");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateGameFromExcel()
        {
            return View();
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

            return View(Game);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateGame([FromForm] UpdateGameCommand Game)
        {
            await Mediator.Send(Game);
            return RedirectToAction("GetAllGames");
        }

        public async ValueTask<IActionResult> DeleteGame(int Id)
        {
            await Mediator.Send(new DeleteGameCommand(Id));

            return RedirectToAction("GetAllGames");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewGame(int id)
        {
            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return View("ViewGame", Game);
        }
    }
}
