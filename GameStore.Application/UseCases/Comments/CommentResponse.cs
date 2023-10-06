using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Application.UseCases.Comments
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<Comment>? ChildComments { get; set; }

        public DateTime Created { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public int? LastModifiedBy { get; set; }
    }
}
