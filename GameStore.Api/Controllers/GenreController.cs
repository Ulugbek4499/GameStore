using GameStore.Application.UseCases.Genres;
using GameStore.Application.UseCases.Genres.Commands.CreateGenre;
using GameStore.Application.UseCases.Genres.Commands.DeleteGenre;
using GameStore.Application.UseCases.Genres.Commands.UpdateGenre;
using GameStore.Application.UseCases.Genres.Queries.GetAllGenres;
using GameStore.Application.UseCases.Genres.Queries.GetGenreById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateGenre(CreateGenreCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<GenreResponse> GetGenreById(int Id)
        {
            return await _mediator.Send(new GetGenreByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<GenreResponse>> GetAllGenres()
        {
            return await _mediator.Send(new GetAllGenresQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateGenre(UpdateGenreCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteGenre(DeleteGenreCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
