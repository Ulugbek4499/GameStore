﻿using GameStore.Domain.Common;
using GameStore.Domain.Entities.Identity;

namespace GameStore.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public  ICollection<int>? GameIds { get; set; }
    public virtual ICollection<Game>? Games { get; set; }
}
