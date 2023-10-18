﻿using GameStore.Application.Common.Interfaces;
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
            await Mediator.Send(Order);

            return RedirectToAction("Index", "Home");
        }

    }
}
