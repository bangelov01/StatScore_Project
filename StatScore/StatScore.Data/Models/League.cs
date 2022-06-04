namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static StatScore.Data.Constants.DataConstants;

    public class League
    {
        public League()
        {
            this.PlayerLeagueStats = new HashSet<PlayerLeagueStats>();
            this.LeagueStats = new HashSet<LeagueStats>();
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; init; }

        [Required, MaxLength(LeagueNameMaxLength)]
        public string Name { get; set; }

        public int Season { get; set; }

        [Required, Column(TypeName = "nvarchar(2048)")]
        public string LogoURL { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; init; }

        public virtual Country Country { get; init; }

        public virtual ICollection<LeagueStats> LeagueStats { get; init; }

        public virtual ICollection<PlayerLeagueStats> PlayerLeagueStats { get; init; }

        public virtual ICollection<Game> Games { get; init; }
    }
}
