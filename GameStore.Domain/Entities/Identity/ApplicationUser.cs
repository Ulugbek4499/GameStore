using Microsoft.AspNetCore.Identity;

namespace GameStore.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Photo { get; set; }

    public virtual ICollection<Game>? Games { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}
