using GameStore.Domain.Common;
using GameStore.Domain.Entities.Identity;
using GameStore.Domain.States;

namespace GameStore.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public CartStatus CartStatus { get; set; } = CartStatus.OnSale;

    public virtual ICollection<CartItem>? CartItems { get; set; }
}
