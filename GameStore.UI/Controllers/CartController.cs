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

        // [HttpGet("[action]")]
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
    }
}
