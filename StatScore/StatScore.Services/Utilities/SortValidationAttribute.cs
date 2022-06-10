namespace StatScore.Services.Utilities
{
    using StatScore.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class SortValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value.Equals(nameof(PlayerLeagueStats.Goals)) ||
                value.Equals(nameof(PlayerLeagueStats.Assists)) ||
                value.Equals(nameof(PlayerLeagueStats.Appearences)))
            {
                return true;
            }

            return false;
        }
    }
}
