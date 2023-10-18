using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateOrder(CreateOrderCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
