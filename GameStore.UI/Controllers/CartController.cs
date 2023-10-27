using CartItemStore.Application.UseCases.CartItems.Commands.DeleteCartItem;
using GameStore.Application.UseCases.CartItems.Commands.CreateCartItem;
using GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem;
using GameStore.Application.UseCases.CartItems.Queries.GetAllCartItems;
using GameStore.Application.UseCases.Carts.Queries.GetCartByUserId;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class CartController : ApiBaseController
    {

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewCart(string id)
        {
            var Cart = await Mediator.Send(new GetCartByUserIdQuery(id));

            return View("ViewCart", Cart);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetCountOfItems(string userId)
        {
            var cart = await Mediator.Send(new GetCartByUserIdQuery(userId));
            int count = 0;

            if (cart != null && cart.CartItems != null)
            {
                count = cart.CartItems.Sum(item => item.Count ?? 0);
            }

            return Json(count);
        }

        //Cart Item
        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateCartItem([FromForm] CreateCartItemCommand CartItem)
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

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateCartItemUp(int Id)
        {
            var cart = await Mediator.Send(new GetCartByCartItemIdQuery(Id));

            await Mediator.Send(new UpdateCartItemUpCommand(Id));

            return View("ViewCart", cart);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateCartItemDown(int Id)
        {
            var cart = await Mediator.Send(new GetCartByCartItemIdQuery(Id));

            await Mediator.Send(new UpdateCartItemDownCommand(Id));

            return View("ViewCart", cart);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> DeleteCartItem(int Id)
        {
            var cart = await Mediator.Send(new GetCartByCartItemIdQuery(Id));

            await Mediator.Send(new DeleteCartItemCommand(Id));


            return View("ViewCart", cart);
        }
    }
}
