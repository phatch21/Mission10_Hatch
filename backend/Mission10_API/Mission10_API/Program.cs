using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Mission10_API.Models; // Adjust namespace

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddDbContext<BowlingDbContext>(options =>
    options.UseSqlite("Data Source=BowlingLeague.sqlite"));

var app = builder.Build();

app.UseCors("AllowAll"); // Enable CORS

app.MapControllers();
app.Run();


