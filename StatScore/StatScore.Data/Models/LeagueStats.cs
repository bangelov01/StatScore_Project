namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LeagueStats
    {
        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; init; }

        public virtual Team Team { get; init; }

        [Required]
        [ForeignKey(nameof(League))]
        public int LeagueId { get; init; }

        public virtual League League { get; init; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }
    }
}
