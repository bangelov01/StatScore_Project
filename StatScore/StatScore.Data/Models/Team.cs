namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static StatScore.Data.Constants.DataConstants;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.LeagueStats = new HashSet<LeagueStats>();
            this.Favorites = new HashSet<Favorites>();
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }

        [Key]
        public int Id { get; init; }

        [Required, MaxLength(TeamNameMaxLength)]
        public string Name { get; set; }

        public byte Trophies { get; set; }

        [Column(TypeName = "decimal(19, 2)")]
        public decimal Budget { get; set; }

        [Required, Column(TypeName = "nvarchar(2048)")]
        public string LogoURL { get; set; }

        public virtual ICollection<Player> Players { get; init; }

        public virtual ICollection<LeagueStats> LeagueStats { get; init; }

        public virtual ICollection<Favorites> Favorites { get; init; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeGames { get; init; }

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayGames { get; init; }
    }
}
