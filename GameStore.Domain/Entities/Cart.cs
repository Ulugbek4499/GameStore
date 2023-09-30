using GameStore.Domain.Common;

namespace GameStore.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public virtual ICollection<CartItem>? CartItems { get; set; }
}
