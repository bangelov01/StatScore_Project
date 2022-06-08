namespace StatScore.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using StatScore.Data.Models;

    public class SSDbContext : IdentityDbContext<User>
    {
        public SSDbContext(DbContextOptions<SSDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Country> Countries { get; init; }
        public virtual DbSet<Game> Games { get; init; }
        public virtual DbSet<League> Leagues { get; init; }
        public virtual DbSet<LeagueStats> LeagueStats { get; init; }
        public virtual DbSet<Player> Players { get; init; }
        public virtual DbSet<PlayerLeagueStats> PlayerLeagueStats { get; init; }
        public virtual DbSet<Team> Teams { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LeagueStats>()
                .HasKey(k => new { k.TeamId, k.LeagueId });

            builder.Entity<PlayerLeagueStats>()
                   .HasKey(k => new { k.PlayerId, k.LeagueId });

            base.OnModelCreating(builder);
        }
    }
}
