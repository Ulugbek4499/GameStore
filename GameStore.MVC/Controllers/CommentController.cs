using GameStore.Application.UseCases.Comments.Commands.CreateComment;
using GameStore.Application.UseCases.Comments.Commands.DeleteComment;
using GameStore.Application.UseCases.Comments.Commands.UpdateComment;
using GameStore.Application.UseCases.Comments.Queries.GetAllComments;
using GameStore.Application.UseCases.Comments.Queries.GetCommentById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class CommentController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateComment()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateComment([FromForm] CreateCommentCommand Comment)
        {
            await Mediator.Send(Comment);

            return RedirectToAction("GetAllComments");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateCommentFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllComments()
        {
            var Comments = await Mediator.Send(new GetAllCommentsQuery());

            return View(Comments);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateComment(int Id)
        {
            var Comment = await Mediator.Send(new GetCommentByIdQuery(Id));

            return View(Comment);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateComment([FromForm] UpdateCommentCommand Comment)
        {
            await Mediator.Send(Comment);
            return RedirectToAction("GetAllComments");
        }

        public async ValueTask<IActionResult> DeleteComment(int Id)
        {
            await Mediator.Send(new DeleteCommentCommand(Id));

            return RedirectToAction("GetAllComments");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewComment(int id)
        {
            var Comment = await Mediator.Send(new GetCommentByIdQuery(id));

            return View("ViewComment", Comment);
        }
    }
}
