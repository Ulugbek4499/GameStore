using GameStore.Domain.Common;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public decimal TotalSum { get; set; }
    public int CountOfItems { get; set; }
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
