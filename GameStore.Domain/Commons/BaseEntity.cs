using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Domain.Common;

public abstract class BaseEntity
{

    public int Id { get; set; }
}
