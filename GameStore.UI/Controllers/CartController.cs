using GameStore.Application.UseCases.Carts.Commands.CreateCart;
using GameStore.Application.UseCases.Carts.Queries.GetCartById;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.UI.Controllers
{
    public class CartController : ApiBaseController
    {

         [HttpGet("[action]")]
         public async ValueTask<IActionResult> ViewCart(int id)
         {
             var Cart = await Mediator.Send(new GetCartByIdQuery(id));

             return View("ViewCart", Cart);
         }
    }
}
