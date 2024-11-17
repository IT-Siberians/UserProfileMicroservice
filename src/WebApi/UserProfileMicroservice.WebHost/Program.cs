using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.BusinessLogic.Services.Implementations;
using UserProfileMicroservice.DataAccess.EntityFramework;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;
using UserProfileMicroservice.DataAccess.Repositories.Implementations.EntityFramework;
using UserProfileMicroservice.WebHost.Helpers;
using UserProfileMicroservice.WebHost.Services;

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

var rmqConnectionString = builder.Configuration["RMQ_CONNECTION_STRING"];
if (string.IsNullOrEmpty(rmqConnectionString))
    throw new InvalidOperationException("Connection string for rabbitMQ is not configured.");

builder.Services.AddScoped<IUserProfileRepository, EFUserProfileRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString)
    .AddRabbitMQ(rabbitConnectionString: rmqConnectionString)
    .AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program).Assembly);
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(rmqConnectionString));
        cfg.ConfigureEndpoints(context);
        cfg.UseMessageRetry(r =>
        {
            r.Interval(3, TimeSpan.FromSeconds(10));
        });
    });
});

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

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.Run();
