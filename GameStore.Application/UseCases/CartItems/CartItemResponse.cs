using GameStore.Domain.Entities;

namespace GameStore.Application.UseCases.CartItems.Response
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
        public int? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
    }
}
