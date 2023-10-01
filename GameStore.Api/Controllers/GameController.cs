using GameStore.Application.UseCases.Games;
using GameStore.Application.UseCases.Games.Commands.CreateGame;
using GameStore.Application.UseCases.Games.Commands.DeleteGame;
using GameStore.Application.UseCases.Games.Commands.UpdateGame;
using GameStore.Application.UseCases.Games.Queries.GetAllGames;
using GameStore.Application.UseCases.Games.Queries.GetGameById;
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
