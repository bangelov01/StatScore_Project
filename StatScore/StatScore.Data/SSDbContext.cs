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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
