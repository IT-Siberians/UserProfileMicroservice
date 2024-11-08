using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.BusinessLogic.Services.Implementations;
using UserProfileMicroservice.DataAccess.EntityFramework;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;
using UserProfileMicroservice.DataAccess.Repositories.Implementations.EntityFramework;
using UserProfileMicroservice.WebHost.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "User Profile API",
            Description = "The User Profile API for managing user data."
        });
    });

var dbConnectionString = builder.Configuration["DB_CONNECTION_STRING"];
if (string.IsNullOrEmpty(dbConnectionString))
    throw new InvalidOperationException($"Connection string for {nameof(ApplicationDbContext)} is not configured.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(dbConnectionString);
    });

builder.Services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddDbContextCheck<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapControllers();

app.MigrateDatabase<ApplicationDbContext>();

app.Run();
