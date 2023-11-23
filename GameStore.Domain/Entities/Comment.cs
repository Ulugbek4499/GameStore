using GameStore.Domain.Common;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Domain.Entities;

public class Comment : BaseAuditableEntity
{
    public string Text { get; set; }
    public bool IsDeleted { get; set; } = false;

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public int? GameId { get; set; }
    public virtual Game? Game { get; set; }

    public int? ParentCommentId { get; set; }
    public virtual Comment? ParentComment { get; set; }

    public virtual ICollection<Comment>? ChildComments { get; set; }
}
