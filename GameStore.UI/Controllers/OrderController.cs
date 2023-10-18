using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class OrderController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrder()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateOrder([FromForm] CreateOrderCommand Order)
        {
            await Mediator.Send(Order);

            return RedirectToAction("GetAllOrders");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrderFromExcel()
        {
            return View();
        }
    }
}
