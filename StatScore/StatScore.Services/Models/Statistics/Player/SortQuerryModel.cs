namespace StatScore.Services.Models.Statistics.Player
{
    using StatScore.Services.Utilities;
    using System.ComponentModel.DataAnnotations;

    public class SortQuerryModel
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [SortValidation]
        public string Sort { get; set; }
    }
}
