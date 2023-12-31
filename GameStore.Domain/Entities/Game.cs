﻿using GameStore.Domain.Common;

namespace GameStore.Domain.Entities;

public class Game : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public virtual ICollection<Genre>? Genres { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
}
