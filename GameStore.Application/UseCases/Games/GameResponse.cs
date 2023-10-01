using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Application.UseCases.Games
{
    public class GameResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Picture { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Genre>? Genres { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }

        public DateTime Created { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public int? LastModifiedBy { get; set; }
    }
}
