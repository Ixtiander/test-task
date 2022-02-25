using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.BL;
using TestApplication.BL.Interfaces;
using TestApplication.BL.Utils;
using TestApplication.DAL;
using TestApplication.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()!);
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", policy =>
{
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
    db.Migrate();
}

// Configure the HTTP request pipeline.
app.UseCors("corsapp");
app.UseAuthorization();
app.MapControllers();

app.Run();
