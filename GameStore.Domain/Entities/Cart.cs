using GameStore.Domain.Common;

namespace GameStore.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public virtual ICollection<CartItem>? CartItems { get; set; }
    public virtual Order? Order { get; set; }
}
