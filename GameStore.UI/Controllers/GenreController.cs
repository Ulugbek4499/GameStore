using GameStore.Application.UseCases.Genres.Commands.CreateGenre;
using GameStore.Application.UseCases.Genres.Commands.DeleteGenre;
using GameStore.Application.UseCases.Genres.Commands.UpdateGenre;
using GameStore.Application.UseCases.Genres.Queries.GetAllGenres;
using GameStore.Application.UseCases.Genres.Queries.GetGenreById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class GenreController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateGenre()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateGenre([FromForm] CreateGenreCommand Genre)
        {
            await Mediator.Send(Genre);

            return RedirectToAction("GetAllGenres");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateGenreFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllGenres()
        {
            var Genres = await Mediator.Send(new GetAllGenresQuery());

            return View(Genres);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateGenre(int Id)
        {
            var Genre = await Mediator.Send(new GetGenreByIdQuery(Id));

            return View(Genre);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateGenre([FromForm] UpdateGenreCommand Genre)
        {
            await Mediator.Send(Genre);
            return RedirectToAction("GetAllGenres");
        }

        public async ValueTask<IActionResult> DeleteGenre(int Id)
        {
            await Mediator.Send(new DeleteGenreCommand(Id));

            return RedirectToAction("GetAllGenres");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewGenre(int id)
        {
            var Genre = await Mediator.Send(new GetGenreByIdQuery(id));

            return View("ViewGenre", Genre);
        }
    }
}
