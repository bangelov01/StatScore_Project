namespace StatScore.Services.Utilities
{
    using AutoMapper;

    using StatScore.Data.Models;
    using StatScore.Services.Models.League;
    using StatScore.Services.Models.League.Base;
    using StatScore.Services.Models.Statistics.Base;
    using StatScore.Services.Models.Statistics.Game;
    using StatScore.Services.Models.Statistics.Player;
    using StatScore.Services.Models.Statistics.Team;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Teams
            int id = 0;

            this.CreateProjection<LeagueStats, TeamLeagueServiceModel>()
                .ForMember(dest => dest.logoURL, opt => opt.MapFrom(src => src.Team.LogoURL))
                .ForMember(dest => dest.GoalsAquired,
                opt => opt.MapFrom(src => src.Team.HomeGames.Where(g => g.LeagueId == id).Sum(s => s.HomeGoals)
                + src.Team.AwayGames.Where(g => g.LeagueId == id).Sum(s => s.AwayGoals)))
                .ForMember(dest => dest.GoalsConceded,
                opt => opt.MapFrom(src => src.Team.HomeGames.Where(g => g.LeagueId == id).Sum(s => s.AwayGoals)
                + src.Team.AwayGames.Where(g => g.LeagueId == id).Sum(s => s.HomeGoals)));

            this.CreateProjection<IGrouping<string, LeagueStats>, TeamLeagueBaseModel>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Wins, opt => opt.MapFrom(src => src.Sum(s => s.Wins)))
                .ForMember(dest => dest.Losses, opt => opt.MapFrom(src => src.Sum(s => s.Losses)))
                .ForMember(dest => dest.Draws, opt => opt.MapFrom(src => src.Sum(s => s.Draws)));

            //Player
            this.CreateProjection<IGrouping<GroupModel, PlayerLeagueStats>, PlayerLeagueBaseModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Key.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Key.LastName))
                .ForMember(dest => dest.Goals, opt => opt.MapFrom(src => src.Sum(s => s.Goals)))
                .ForMember(dest => dest.Assists, opt => opt.MapFrom(src => src.Sum(s => s.Assists)))
                .ForMember(dest => dest.Appearences, opt => opt.MapFrom(src => src.Sum(s => s.Appearences)));

            this.CreateProjection<PlayerLeagueStats, PlayerLeagueServiceModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Player.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Player.LastName))
                .ForMember(dest => dest.IsInjured, opt => opt.MapFrom(src => src.Player.IsInjured))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Player.Position))
                .ForMember(dest => dest.TeamLogo, opt => opt.MapFrom(src => src.Player.Team.LogoURL));


            //Games
            this.CreateProjection<Game, GameServiceModel>()
                .ForMember(dest => dest.HomeLogoURL, opt => opt.MapFrom(src => src.HomeTeam.LogoURL))
                .ForMember(dest => dest.AwayLogoURL, opt => opt.MapFrom(src => src.AwayTeam.LogoURL));

            //League
            this.CreateProjection<League, LeagueInfoServiceModel>();
            this.CreateProjection<League, LeagueBaseModel>();
        }
    }
}
