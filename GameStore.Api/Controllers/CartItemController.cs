using GameStore.Application.UseCases.CartItems;
using GameStore.Application.UseCases.CartItems.Commands.CreateCartItem;
using GameStore.Application.UseCases.CartItems.Commands.DeleteCartItem;
using GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem;
using GameStore.Application.UseCases.CartItems.Queries.GetAllCartItems;
using GameStore.Application.UseCases.CartItems.Queries.GetCartItemById;
using GameStore.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CartItemStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ApiBaseController
    {
        [HttpPost("[action]")]
        public async ValueTask<int> CreateCartItem(CreateCartItemCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<CartItemResponse> GetCartItemById(int Id)
        {
            return await _mediator.Send(new GetCartItemByIdQuery(Id));
        }

        [HttpGet("[action]")]
        public async ValueTask<IEnumerable<CartItemResponse>> GetAllCartItems()
        {
            return await _mediator.Send(new GetAllCartItemsQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<IActionResult> UpdateCartItem(UpdateCartItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async ValueTask<IActionResult> DeleteCartItem(DeleteCartItemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
