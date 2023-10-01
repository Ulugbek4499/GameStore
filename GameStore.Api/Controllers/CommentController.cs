using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Comments.Commands.CreateComment;
using GameStore.Application.UseCases.Comments.Commands.DeleteComment;
using GameStore.Application.UseCases.Comments.Commands.UpdateComment;
using GameStore.Application.UseCases.Comments.Queries.GetAllComments;
using GameStore.Application.UseCases.Comments.Queries.GetCommentById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateComment(CreateCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<CommentResponse> GetCommentById(int Id)
        {
            return await _mediator.Send(new GetCommentByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<CommentResponse>> GetAllComments()
        {
            return await _mediator.Send(new GetAllCommentsQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteComment(DeleteCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }

}
