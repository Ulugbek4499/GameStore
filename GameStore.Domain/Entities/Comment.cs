using GameStore.Domain.Common;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Domain.Entities;

public class Comment : BaseAuditableEntity
{
    public string Text { get; set; }

    public int UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public int GameId { get; set; }
    public virtual Game Game { get; set; }

    public virtual ICollection<Comment>? ChildComments { get; set; }
}
