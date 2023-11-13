using GameStore.Application.Common.Interfaces;
using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class OrderController : ApiBaseController
    {
        private readonly IApplicationUser _applicationUser;

        public OrderController(IApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateOrder()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateOrder([FromForm] CreateOrderCommand Order)
        {
            Order.UserId = _applicationUser.Id;

            // Assuming Mediator.Send(Order) returns an int representing the order ID
            int orderId = await Mediator.Send(Order);

            if (orderId > 0)
            {
                // Display success message on the same page
                TempData["SuccessMessage"] = "Order successfully created!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle the case where order creation failed
                ViewData["ErrorMessage"] = "Failed to create the order.";
                return View("CreateOrder");
            }
        }
    }
}

/*        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateOrder([FromForm] CreateOrderCommand Order)
        {
            Order.UserId = _applicationUser.Id;
            await Mediator.Send(Order);

            return RedirectToAction("Index", "Home");
        }*/