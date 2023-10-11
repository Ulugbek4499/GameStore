using GameStore.Domain.Entities.Identity;
using GameStore.Domain.Entities;

namespace GameStore.Application.UseCases.Carts
{
    public class CartResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int? GameId { get; set; }
        public virtual Game? Games { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
