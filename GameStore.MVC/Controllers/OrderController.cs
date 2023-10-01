using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using GameStore.Application.UseCases.Orders.Commands.DeleteOrder;
using GameStore.Application.UseCases.Orders.Commands.UpdateOrder;
using GameStore.Application.UseCases.Orders.Queries.GetAllOrders;
using GameStore.Application.UseCases.Orders.Queries.GetOrderById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
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

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllOrders()
        {
            var Orders = await Mediator.Send(new GetAllOrdersQuery());

            return View(Orders);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateOrder(int Id)
        {
            var Order = await Mediator.Send(new GetOrderByIdQuery(Id));

            return View(Order);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateOrder([FromForm] UpdateOrderCommand Order)
        {
            await Mediator.Send(Order);
            return RedirectToAction("GetAllOrders");
        }

        public async ValueTask<IActionResult> DeleteOrder(int Id)
        {
            await Mediator.Send(new DeleteOrderCommand(Id));

            return RedirectToAction("GetAllOrders");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewOrder(int id)
        {
            var Order = await Mediator.Send(new GetOrderByIdQuery(id));

            return View("ViewOrder", Order);
        }
    }
}
