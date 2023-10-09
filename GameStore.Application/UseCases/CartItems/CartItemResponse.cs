using GameStore.Domain.Entities;

namespace GameStore.Application.UseCases.CartItems
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
