using System.ComponentModel.DataAnnotations;

namespace GameStore.Domain.Entities.Identity
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateExpire { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
