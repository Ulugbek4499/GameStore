﻿using GameStore.Domain.Entities;

namespace GameStore.Application.UseCases.CartItems.Response
{
    public class GenreResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
        public virtual Genre ParentGenre { get; set; }

        public virtual ICollection<Genre> ChildGenres { get; set; }
        public virtual ICollection<Game> Games { get; set; }

        public DateTime Created { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public int? LastModifiedBy { get; set; }
    }
}
