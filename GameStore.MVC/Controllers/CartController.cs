using Microsoft.AspNetCore.Mvc;

namespace GameStore.MVC.Controllers
{
    public class CartController : ApiBaseController
    {
        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateCart()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> CreateCart([FromForm] CreateCartCommand Cart)
        {
            await Mediator.Send(Cart);

            return RedirectToAction("GetAllCarts");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> CreateCartFromExcel()
        {
            return View();
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> GetAllCarts()
        {
            var Carts = await Mediator.Send(new GetAllCartsQuery());

            return View(Carts);
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> UpdateCart(int Id)
        {
            var Cart = await Mediator.Send(new GetCartByIdQuery(Id));

            return View(Cart);
        }

        [HttpPost("[action]")]
        public async ValueTask<IActionResult> UpdateCart([FromForm] UpdateCartCommand Cart)
        {
            await Mediator.Send(Cart);
            return RedirectToAction("GetAllCarts");
        }

        public async ValueTask<IActionResult> DeleteCart(int Id)
        {
            await Mediator.Send(new DeleteCartCommand(Id));

            return RedirectToAction("GetAllCarts");
        }

        [HttpGet("[action]")]
        public async ValueTask<IActionResult> ViewCart(int id)
        {
            var Cart = await Mediator.Send(new GetCartByIdQuery(id));

            return View("ViewCart", Cart);
        }
    }
}
