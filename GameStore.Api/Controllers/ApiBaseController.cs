using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiBaseController : Controller
    {
        protected IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
