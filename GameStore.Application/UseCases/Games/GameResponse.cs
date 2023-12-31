﻿using GameStore.Domain.Entities;
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
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Genre>? Genres { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }

        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
