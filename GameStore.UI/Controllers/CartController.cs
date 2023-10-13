using GameStore.Application.UseCases.Carts.Commands.CreateCart;
using GameStore.Application.UseCases.Carts.Queries.GetCartById;
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
    }
}
