using GameStore.Application.UseCases.CartItems.Response;
using GameStore.Application.UseCases.Carts.Commands.CreateCart;
using GameStore.Application.UseCases.Carts.Commands.DeleteCart;
using GameStore.Application.UseCases.Carts.Commands.UpdateCart;
using GameStore.Application.UseCases.Carts.Queries.GetAllCarts;
using GameStore.Application.UseCases.Carts.Queries.GetCartById;
using Microsoft.AspNetCore.Mvc;

namespace CartStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateCart(CreateCartCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpGet("[action]")]
        public async ValueTask<CartResponse> GetCartById(int Id)
        {
            return await _mediator.Send(new GetCartByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<CartResponse>> GetAllCarts()
        {
            return await _mediator.Send(new GetAllCartsQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateCart(UpdateCartCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteCart(DeleteCartCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
