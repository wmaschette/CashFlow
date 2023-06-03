using CashFlow.Api.Middlewares;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using CashFlow.SqlData;
using CashFlow.SqlData.Repositories;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables();

// add services to DI container
{
    var service = builder.Services;
    var connectionString = builder.Configuration["ConnectionString"];

    service.AddDbContext<ApplicationDataContext>(options => options.UseNpgsql(connectionString));

    service.AddControllers();
    service.AddEndpointsApiExplorer();
    service.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cash flow API", Description = "API for daily cash flow control", Version = "v1" });
    });

    service.AddLogging();

    service.AddScoped<IDailyEntryService, DailyEntryService>();
    service.AddScoped<IDailyEntryRepository, DailyEntryRepository>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    // swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
