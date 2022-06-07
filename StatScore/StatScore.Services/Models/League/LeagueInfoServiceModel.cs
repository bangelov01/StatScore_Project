namespace StatScore.Services.Models.League
{
    using StatScore.Services.Models.League.Base;

    public class LeagueInfoServiceModel : LeagueBaseModel
    {
        public int Season { get; init; }
        public string LogoURL { get; init; }
        public string CountryName { get; init; }
    }
}
