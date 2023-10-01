using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Domain.Entities.Identity;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string? Photo { get; set; }

    public virtual ICollection<Game>? Games { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
