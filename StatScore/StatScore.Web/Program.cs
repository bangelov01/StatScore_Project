using Microsoft.EntityFrameworkCore;

using StatScore.Web.Infrastructure;
using StatScore.Data;
using StatScore.Services.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SSDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<AppSettingsModel>(
    builder
    .Configuration
    .GetSection("AdministrationDetails"));

builder.Services.AddControllers();

builder.Services.RegisterTransient();
builder.Services.SetUpIdentityForDevelopment();

builder.AddAuthenticationWithJWT();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.PrepareDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
