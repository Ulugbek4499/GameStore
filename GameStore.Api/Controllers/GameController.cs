using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateGame(CreateGameCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<List<GameResponse>> AddGamesFromExcel(IFormFile excelfile)
        {
            var result = await _mediator.Send(new AddGamesFromExcel(excelfile));
            return result;
        }

        [HttpGet("[action]")]
        public async ValueTask<GameResponse> GetGameById(int Id)
        {
            return await _mediator.Send(new GetGameByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GameResponse>> GetAllGames()
        {
            return await _mediator.Send(new GetAllGamesQuery());
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<PaginatedList<GameResponse>>> GetAllGamesPagination(
            [FromQuery] GetGamesPaginationQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("[action]")]
        public async Task<FileResult> GetGamesInExcel(string fileName = "Game")
        {
            var result = await _mediator.Send(new GetGamesExcel { FileName = fileName });
            return File(result.FileContents, result.Option, result.FileName);
        }

        [HttpGet("[action]")]
        public async Task<FileResult> GetGameByIdPDF(int id)
        {
            var result = await _mediator.Send(new GetGameByIdPDFQuery(id));
            return File(result.FileContents, result.Options, result.FileName);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<FormFile>> GetClaimGamePdfTemplate(int id)
        {
            var result = await _mediator.Send(new GetGamePDFQuery(id));

            return File(result.FileContents, result.Options, result.FileName);
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateGame(UpdateGameCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteGame(DeleteGameCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
