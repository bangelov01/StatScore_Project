namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static StatScore.Data.Constants.DataConstants;

    public class Player
    {
        public Player()
        {
            this.PlayerLeagueStats = new HashSet<PlayerLeagueStats>();
        }

        [Key]
        public int Id { get; init; }

        [Required, MaxLength(PlayerNameMaxLength)]
        public string Name { get; set; }

        public bool IsInjured { get; set; }

        [Required, MaxLength(PlayerPositionMaxLength)]
        public string Position { get; set; }

        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required, Column(TypeName = "nvarchar(2048)")]
        public string LogoURL { get; set; }

        public virtual ICollection<PlayerLeagueStats> PlayerLeagueStats { get; init; }
    }
}
