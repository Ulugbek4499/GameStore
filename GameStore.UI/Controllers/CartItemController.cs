using CartItemStore.Application.UseCases.CartItems.Commands.DeleteCartItem;
using CartItemStore.Application.UseCases.CartItems.Queries.GetCartItemById;
using GameStore.Application.UseCases.CartItems.Commands.CreateCartItem;
using GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem;
using GameStore.Application.UseCases.CartItems.Queries.GetAllCartItems;
using GameStore.Application.UseCases.Carts.Queries.GetCartByUserId;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class CartItemController: ApiBaseController
    {

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateCartItem([FromForm]  CreateCartItemCommand CartItem)
        {
            await Mediator.Send(CartItem);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllCartItems()
        {
            var CartItems = await Mediator.Send(new GetAllCartItemsQuery());

            return View(CartItems);
        }

        public async ValueTask<IActionResult> UpdateCartItemUp(int Id)
        {
            await Mediator.Send(new UpdateCartItemUpCommand(Id));
        }

        public async ValueTask<IActionResult> DeleteCartItem(int Id)
        {
            await Mediator.Send(new DeleteCartItemCommand(Id));

            var cart = await Mediator.Send(new GetCartByCartItemIdQuery(Id));

            return RedirectToAction("Cart/ViewCart", cart);
        }
    }
}
