using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class FounderController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateFounder()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateFounder([FromForm] CreateFounderCommand Founder)
        {
            await Mediator.Send(Founder);

            return RedirectToAction("GetAllFounders");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateFounderFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllFounders()
        {
            var Founders = await Mediator.Send(new GetAllFoundersQuery());

            return View(Founders);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateFounder(int Id)
        {
            var Founder = await Mediator.Send(new GetFounderByIdQuery(Id));

            return View(Founder);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateFounder([FromForm] UpdateFounderCommand Founder)
        {
            await Mediator.Send(Founder);
            return RedirectToAction("GetAllFounders");
        }

        public async ValueTask<IActionResult> DeleteFounder(int Id)
        {
            await Mediator.Send(new DeleteFounderCommand(Id));

            return RedirectToAction("GetAllFounders");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewFounder(int id)
        {
            var Founder = await Mediator.Send(new GetFounderByIdQuery(id));

            return View("ViewFounder", Founder);
        }
    }
}
