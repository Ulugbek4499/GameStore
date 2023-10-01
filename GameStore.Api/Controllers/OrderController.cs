using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Orders.Commands.CreateOrder;
using GameStore.Application.UseCases.Orders.Commands.DeleteOrder;
using GameStore.Application.UseCases.Orders.Commands.UpdateOrder;
using GameStore.Application.UseCases.Orders.Queries.GetAllOrders;
using GameStore.Application.UseCases.Orders.Queries.GetOrderById;
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


        [HttpGet("[action]")]
        public async ValueTask<OrderResponse> GetOrderById(int Id)
        {
            return await _mediator.Send(new GetOrderByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<OrderResponse>> GetAllOrders()
        {
            return await _mediator.Send(new GetAllOrdersQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteOrder(DeleteOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
