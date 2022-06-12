namespace StatScore.Services
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.EntityFrameworkCore;

    using StatScore.Data;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models.League;
    using StatScore.Services.Models.League.Base;

    public class LeagueService : ILeagueService
    {
        private readonly SSDbContext dbContext;
        private readonly IConfigurationProvider mapper;

        public LeagueService(SSDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper.ConfigurationProvider;
        }

        public async Task<LeagueInfoServiceModel> LeagueFullInfo(int id)
            => await dbContext
            .Leagues
            .Where(x => x.Id == id)
            .ProjectTo<LeagueInfoServiceModel>(mapper)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<LeagueBaseModel>> LeaguesBaseInfo()
            => await dbContext
            .Leagues
            .ProjectTo<LeagueBaseModel>(mapper)
            .ToArrayAsync();
    }
}
