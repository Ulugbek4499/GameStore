using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Application.UseCases.Comments
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public int ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }

        public virtual ICollection<Comment> ChildComments { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
