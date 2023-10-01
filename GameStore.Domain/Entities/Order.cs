using GameStore.Domain.Common;
using GameStore.Domain.States;

namespace GameStore.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public PaymentType PaymentType { get; set; }
    public string? Comment { get; set; }

    public int CartId { get; set; }
    public virtual Cart Cart { get; set; }
}
