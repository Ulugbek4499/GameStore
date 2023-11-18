using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.Comments.Commands.CreateComment;
using GameStore.Application.UseCases.Comments.Commands.DeleteComment;
using GameStore.Application.UseCases.Comments.Commands.UpdateComment;
using GameStore.Application.UseCases.Comments.Queries.GetAllComments;
using GameStore.Application.UseCases.Comments.Queries.GetCommentById;
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
        private readonly IApplicationUser _applicationUser;

        public GameController(IApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }

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




        //COMMENT Section


        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateComment([FromForm] CreateCommentCommand Comment)
        {
            Comment.UserId = _applicationUser.Id;
            int id = Comment.GameId ?? 0;

            await Mediator.Send(Comment);

            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return View("ViewGame", Game);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> DeleteComment(int Id)
        {
            var Comment = await Mediator.Send(new GetCommentByIdQuery(Id));
            int id = Comment.GameId;

            await Mediator.Send(new DeleteCommentCommand(Id));

            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return View("ViewGame", Game);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllComments()
        {
            var Comments = await Mediator.Send(new GetAllCommentsQuery());

            return View(Comments);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateComment([FromForm] UpdateCommentCommand Comment)
        {
            Comment.UserId = _applicationUser.Id;
            await Mediator.Send(Comment);

            int id = Comment.GameId ?? 0;
            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return View("ViewGame", Game);
        }


        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetCommentById(int id)
        {
            var Comment = await Mediator.Send(new GetCommentByIdQuery(id));

            return View("ViewComment", Comment);
        }
    }
}
