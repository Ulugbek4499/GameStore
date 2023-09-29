using GameStore.Domain.Common;

namespace GameStore.Domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<Comment>? ChildComments { get; set; }
    }
}
