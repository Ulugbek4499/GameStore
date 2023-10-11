using GameStore.Domain.Common;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public int? GameId { get; set; }
    public virtual Game? Game { get; set; }

}
