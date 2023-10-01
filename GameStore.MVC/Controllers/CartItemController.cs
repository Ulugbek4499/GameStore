using GameStore.Application.UseCases.CartItems.Commands.CreateCartItem;
using GameStore.Application.UseCases.CartItems.Commands.DeleteCartItem;
using GameStore.Application.UseCases.CartItems.Commands.UpdateCartItem;
using GameStore.Application.UseCases.CartItems.Queries.GetAllCartItems;
using GameStore.Application.UseCases.CartItems.Queries.GetCartItemById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class CartItemController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateCartItem()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateCartItem([FromForm] CreateCartItemCommand CartItem)
        {
            await Mediator.Send(CartItem);

            return RedirectToAction("GetAllCartItems");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateCartItemFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllCartItems()
        {
            var CartItems = await Mediator.Send(new GetAllCartItemsQuery());

            return View(CartItems);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateCartItem(int Id)
        {
            var CartItem = await Mediator.Send(new GetCartItemByIdQuery(Id));

            return View(CartItem);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateCartItem([FromForm] UpdateCartItemCommand CartItem)
        {
            await Mediator.Send(CartItem);
            return RedirectToAction("GetAllCartItems");
        }

        public async ValueTask<IActionResult> DeleteCartItem(int Id)
        {
            await Mediator.Send(new DeleteCartItemCommand(Id));

            return RedirectToAction("GetAllCartItems");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewCartItem(int id)
        {
            var CartItem = await Mediator.Send(new GetCartItemByIdQuery(id));

            return View("ViewCartItem", CartItem);
        }
    }
}
