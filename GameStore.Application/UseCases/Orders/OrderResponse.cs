using GameStore.Domain.Entities;
using GameStore.Domain.States;

namespace GameStore.Application.UseCases.Orders
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PaymentType PaymentType { get; set; }
        public string? Comment { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
