namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {

        [Key]
        public int GameId { get; init; }

        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; init; }
        public virtual Team HomeTeam { get; init; }

        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; init; }
        public virtual Team AwayTeam { get; init; }

        [Required]
        [ForeignKey(nameof(League))]
        public int LeagueId { get; init; }
        public virtual League League { get; init; }

        public byte HomeGoals { get; set; }

        public byte AwayGoals { get; set; }

        public byte HomeShots { get; set; }

        public byte AwayShots { get; set; }

        public int HomePasses { get; set; }

        public int AwayPasses { get; set; }

        public byte HomeFauls { get; set; }

        public byte AwayFauls { get; set; }

        public DateTime Date { get; set; }
    }
}
