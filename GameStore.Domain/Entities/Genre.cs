using GameStore.Domain.Common;

namespace GameStore.Domain.Entities
{
    public class Genre : BaseAuditableEntity
    {
        public string Name { get; set; }

        public int? ParentGenreId { get; set; }
        public virtual Genre ParentGenre { get; set; }

        public virtual ICollection<Genre> ChildGenres { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
