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

        public byte HomeTeamGoals { get; set; }

        public byte AwayTeamGoals { get; set; }

        public byte HomeTeamShots { get; set; }

        public byte AwayTeamShots { get; set; }

        public int HomeTeamPasses { get; set; }

        public int AwayTeamPasses { get; set; }

        public byte HomeTeamFauls { get; set; }

        public byte AwayTeamFauls { get; set; }

        public DateTime Date { get; set; }
    }
}
