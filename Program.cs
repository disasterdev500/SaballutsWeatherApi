using Microsoft.EntityFrameworkCore;
using SaballutsWeather.DbModels;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<SaballutsWeatherContext>(options=>{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SaballutsWeatherConnection"));
});

// HealthChecks
builder.Services.AddHealthChecks().AddDbContextCheck<SaballutsWeatherContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/healthz", new HealthCheckOptions{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse // improve healthchecks response
});


app.Run();

