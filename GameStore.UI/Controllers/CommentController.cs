using GameStore.Application.UseCases.Comments.Commands.CreateComment;
using GameStore.Application.UseCases.Comments.Commands.DeleteComment;
using GameStore.Application.UseCases.Comments.Commands.UpdateComment;
using GameStore.Application.UseCases.Comments.Queries.GetAllComments;
using GameStore.Application.UseCases.Comments.Queries.GetCommentById;
using GameStore.Application.UseCases.Games.Queries.GetGameById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class CommentController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateComment([FromForm] CreateCommentCommand Comment)
        {
            await Mediator.Send(Comment);
            int id = Comment.GameId ?? 0; 

            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return RedirectToAction("Game", "ViewGame", Game);
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
            await Mediator.Send(Comment);

            int id = Comment.GameId ?? 0;
            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return RedirectToAction("Game", "ViewGame", Game);
        }

        public async ValueTask<IActionResult> DeleteComment(int Id)
        {
            var Comment = await Mediator.Send(new GetCommentByIdQuery(Id));
            int id = Comment.GameId;

            await Mediator.Send(new DeleteCommentCommand(Id));

            var Game = await Mediator.Send(new GetGameByIdQuery(id));

            return RedirectToAction("Game", "ViewGame", Game);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetCommentById(int id)
        {
            var Comment = await Mediator.Send(new GetCommentByIdQuery(id));

            return View("ViewComment", Comment);
        }
    }
}
