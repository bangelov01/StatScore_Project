namespace StatScore.Web.Infrastructure
{
    using System.Net;
    using System.Text;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    using StatScore.Data;
    using StatScore.Data.Models;
    using StatScore.Services;
    using StatScore.Services.Contracts;
    using StatScore.Services.Models;

    public static class WebApplicationExtensions
    {
        public async static Task<WebApplication> PrepareDatabase(this WebApplication app)
        {
            using var scopedServices = app.Services.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;

            await Migrate(serviceProvider);

            await Seed(serviceProvider);

            return app;
        }

        public static void ConfigureExceptionHandler( this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetailsModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }

        public static void RegisterTransient(this IServiceCollection services)
        {
            services.AddTransient<IDataSeederService, DataSeederService>();
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }

        public static void SetUpIdentityForDevelopment(this IServiceCollection services)
        {
            services.AddDefaultIdentity<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SSDbContext>();
        }

        public static WebApplicationBuilder AddAuthenticationWithJWT(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                       .AddJwtBearer(options =>
                       {
                           options.SaveToken = true;
                           options.RequireHttpsMetadata = false;
                           options.TokenValidationParameters = new TokenValidationParameters()
                           {
                               ValidateIssuer = true,
                               ValidateAudience = true,
                               ValidAudience = builder.Configuration["JWT:ValidAudience"],
                               ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                           };

                       });

            return builder;
        }

        private async static Task Migrate(IServiceProvider provider)
        {
            var data = provider.GetRequiredService<SSDbContext>();

            await data.Database.MigrateAsync();
        }

        private async static Task Seed(IServiceProvider provider)
        {
            var seeder = provider.GetRequiredService<IDataSeederService>();

            await seeder.SeedAdministrator();

            await seeder.SeedCountry();

            await seeder.SeedLeagues();

            await seeder.SeedTeams();

            await seeder.SeedLeagueStats();

            await seeder.SeedGames();

            await seeder.SeedPlayers();

            await seeder.SeedPlayerLeagueStats();
        }
    }
}
