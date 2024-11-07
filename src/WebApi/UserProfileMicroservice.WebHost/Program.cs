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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException($"Connection string for {nameof(ApplicationDbContext)} is not configured.");
        options.UseNpgsql(connectionString);
    });

builder.Services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.MigrateDatabase<ApplicationDbContext>();

app.Run();
