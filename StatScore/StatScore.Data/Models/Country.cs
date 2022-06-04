namespace StatScore.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static StatScore.Data.Constants.DataConstants;

    public class Country
    {
        public Country()
        {
            this.Leagues = new HashSet<League>();
        }

        [Key]
        public int Id { get; init; }

        [Required, MaxLength(CountryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<League> Leagues { get; init; }
    }
}
