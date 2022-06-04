namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PlayerLeagueStats
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int PlayerId { get; init; }

        public virtual Player Player { get; init; }

        [Required]
        [ForeignKey(nameof(Team))]
        public int LeagueId { get; init; }

        public virtual League League { get; init; }

        public byte Goals { get; set; }

        public byte Assists { get; set; }

        public byte Appearences { get; set; }
    }
}
